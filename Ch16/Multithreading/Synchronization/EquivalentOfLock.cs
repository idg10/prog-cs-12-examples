﻿namespace Synchronization;

class EquivalentOfLock
{
    private readonly object _sync = new();

    private decimal _total;

    private readonly List<string> _saleDetails = new();

    public decimal Total
    {
        get
        {
            lock (_sync)
            {
                return _total;
            }
        }
    }

    public void AddSale(string item, decimal price)
    {
        string details = $"{item} sold at {price}";
        bool lockWasTaken = false;
        object temp = _sync;
        try
        {
            Monitor.Enter(temp, ref lockWasTaken);
            {
                _total += price;
                _saleDetails.Add(details);
            }
        }
        finally
        {
            if (lockWasTaken)
            {
                Monitor.Exit(temp);
            }
        }
    }

    public string[] GetDetails(out decimal total)
    {
        bool lockWasTaken = false;
        object temp = _sync;
        try
        {
            Monitor.Enter(temp, ref lockWasTaken);
            {
                total = _total;
                return _saleDetails.ToArray();
            }
        }
        finally
        {
            if (lockWasTaken)
            {
                Monitor.Exit(temp);
            }
        }
    }
}
