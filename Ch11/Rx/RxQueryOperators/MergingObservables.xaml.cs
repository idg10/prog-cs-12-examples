using System.Reactive;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Input;

namespace RxQueryOperators;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MergingObservables : Window
{
    public MergingObservables()
    {
        InitializeComponent();

        IObservable<EventPattern<MouseEventArgs>> downs =
            Observable.FromEventPattern<MouseButtonEventHandler, MouseEventArgs>(
                h => background.MouseDown += h, h => background.MouseDown -= h);
        IObservable<EventPattern<MouseEventArgs>> ups =
            Observable.FromEventPattern<MouseButtonEventHandler, MouseEventArgs>(
                h => background.MouseUp += h, h => background.MouseUp -= h);
        IObservable<EventPattern<MouseEventArgs>> allMoves =
            Observable.FromEventPattern<MouseEventHandler, MouseEventArgs>(
                h => background.MouseMove += h, h => background.MouseMove -= h);

        IObservable<EventPattern<MouseEventArgs>> dragMoves =
            from move in allMoves
            where Mouse.Captured == background
            select move;

        IObservable<EventPattern<MouseEventArgs>> allDragPositionEvents =
            Observable.Merge(downs, ups, dragMoves);

        IObservable<Point> dragPositions =
            from move in allDragPositionEvents
            select move.EventArgs.GetPosition(background);

        dragPositions.Subscribe(point => { line.Points.Add(point); });
    }

    private void OnBackgroundMouseDown(object sender, MouseButtonEventArgs e)
    {
        background.CaptureMouse();
    }

    private void OnBackgroundMouseUp(object sender, MouseButtonEventArgs e)
    {
        if (Mouse.Captured == background)
        {
            background.ReleaseMouseCapture();
        }
    }
}