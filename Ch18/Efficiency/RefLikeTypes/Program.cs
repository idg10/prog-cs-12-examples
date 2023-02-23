using RefLikeTypes;

int i = 21;
RefLike<int> ri = new(ref i);
ri.Ref *= 2;
Console.WriteLine(i);

// To see the compiler error that this code causes, change the next line to
// #if true
#if false
static void Bad(ref RefSmuggler<int> rs)
{
    int local = 123;
    RefLike<int> rli = new(ref local);
    rs.ChangeTarget(rli); // Won't compile
}

void LooksBad(ref NoRefCapture<int> r)
{
    int local1 = 123;
    int local2 = 456;
    RefLike<int> rli1 = new(ref local1);
    RefLike<int> rli2 = new(ref local2);
    r.UseRef(rli1, rli2); // Won't compile
}
#endif

