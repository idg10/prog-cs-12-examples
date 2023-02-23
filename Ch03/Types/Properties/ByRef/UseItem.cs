namespace Properties.ByRef;

using System.Windows;

class UseItem
{
    public static void ModifyPropertyByRef()
    {
        var item = new Item();
        ref Point location = ref item.Location;
        location.X = 123;
    }
}
