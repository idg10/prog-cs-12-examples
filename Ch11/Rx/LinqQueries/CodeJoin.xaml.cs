using System.Reactive;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Input;

namespace LinqQueries;

/// <summary>
/// Interaction logic for CodeJoin.xaml
/// </summary>
public partial class CodeJoin : Window
{
    public CodeJoin()
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

        IObservable<Point> dragPositions = downs.Join(
            allMoves,
            down => ups,
            move => allMoves,
            (down, move) => move.EventArgs.GetPosition(background));

        dragPositions.Subscribe(point => { line.Points.Add(point); });
    }
}