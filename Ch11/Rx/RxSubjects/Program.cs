using RxSubjects;

var kw = new KeyWatcher();
kw.Keys.Subscribe(Console.WriteLine);
kw.Run();