using System;

class Punkt
{
    private int x, y;
    public Punkt() 
    {
        this.x = 0;
        this.y = 0;
    }

    public Punkt(int x,int y) 
    {
        this.x = x;
        this.y = y;
    }

    public Punkt ( Punkt punkt)
    {
        this.x = punkt.x;
        this.y = punkt.y;
    }

    public override string ToString()
    {
        return "( " + this.x + " , " + this.y + " )";
    }
    public void przesun(int x,int y)
    {
        this.x += x;
        this.y += y;
    }
}

class Linia
{
    private Punkt first, second;

    public Linia()
    {
        this.first = new Punkt();
        this.second = new Punkt();
    }

    public Linia(Punkt first,Punkt second)
    {
        this.first = first;
        this.second = second;
    }

    public Linia(Linia line)
    {
        this.first = line.first;
        this.second = line.second;
    }

    public override string ToString()
    {
        return "[ " + this.first.ToString() + " ; " 
            + this.second.ToString() + " ]";
    }
    public void przesun(int x,int y)
    {
        this.first.przesun(x, y);
        this.second.przesun(x, y);
    }

}

class Trojkat 
{
    private Linia linia1, linia2, linia3;

    public Trojkat()
    {
        this.linia1 = new Linia();
        this.linia2 = new Linia();
        this.linia3 = new Linia();
    }
    public Trojkat(Punkt a, Punkt b, Punkt c)
    {
        this.linia1 = new Linia(a,b);
        this.linia2 = new Linia(b,c);
        this.linia3 = new Linia(c,a);
    }
    public Trojkat(Trojkat tr)
    {
        this.linia1 = tr.linia1;
        this.linia2 = tr.linia2;
        this.linia3 = tr.linia3;
    }
    public override string ToString()
    {
        return "{ " +this.linia1.ToString()+" | " + this.linia2.ToString() + 
            " | " + this.linia3.ToString() + " }";
    }
    public void przesun(int x, int y)
    {
        this.linia1.przesun(x, y);
        this.linia2.przesun(x, y);
        this.linia3.przesun(x, y);
        
    }
}
class Czworokat 
{
    private  Linia linia1, linia2, linia3,linia4;

    public Czworokat()
    {
        this.linia1 = new Linia();
        this.linia2 = new Linia();
        this.linia3 = new Linia();
        this.linia4 = new Linia();
    }
    public Czworokat (Punkt a, Punkt b, Punkt c, Punkt d)
    {
        this.linia1 = new Linia(a, b);
        this.linia2 = new Linia(b, c);
        this.linia3 = new Linia(c, d);
        this.linia4 = new Linia(d, a);
    }

    public Czworokat(Czworokat cz)
    {
        this.linia1 = cz.linia1;
        this.linia2 = cz.linia2;
        this.linia3 = cz.linia3;
        this.linia4 = cz.linia4;
    }

    public override string ToString()
    {
        return "{ " + this.linia1.ToString() + " | " + this.linia2.ToString() + " | " + this.linia3.ToString() + 
            " | " + this.linia4.ToString() + " }";
    }
    public void przesun(int x, int y)
    {
        this.linia1.przesun(x, y);
        this.linia2.przesun(x, y);
        this.linia3.przesun(x, y);
        this.linia4.przesun(x, y);
    }
}

class Obraz
{
    private object [] arr ;
    private int max;
    private int curr;
    public Obraz()
    {
        max = 5;
        arr = new object[max];
        curr = 0;
    }
    public void dodaj(object obj)
    {
        if (max >= curr)
        {
            object[] temp = new object[max+5];
            for (int i = 0; i < max; i++) 
            {
                temp[i] = this.arr[i];
            }
            this.arr = temp;
            this.max += 5;
        }
        this.arr[curr] = obj;
        this.curr++;
    }
    public override string ToString()
    {
        string ret;
        ret = "/\\\n";
        for(int i=0;i<this.curr;i++)
        {
            ret = ret +this.arr[i].ToString() + "\n";
        }
        ret += "\\/";
        return ret;
    }
    public void przesun(int x,int y)
    {
        for (int i = 0; i < this.curr; i++) 
        {
            if (this.arr[0].GetType().ToString() == "Trojkat")
            {
                ((Trojkat)this.arr[0]).przesun(x,y);
            }else if (this.arr[0].GetType().ToString() == "Czworokat")
            {
                ((Czworokat)this.arr[0]).przesun(x, y);
            }
            else if (this.arr[0].GetType().ToString() == "Linia")
            {
                ((Linia)this.arr[0]).przesun(x, y);
            }
            else if (this.arr[0].GetType().ToString() == "Punkt")
            {
                ((Punkt)this.arr[0]).przesun(x, y);
            }
        }   
    }
}
namespace zad6._1figury
{
    class Program
    {
        static void Main(string[] args)
        {
            var tr = new Trojkat(new Punkt(1, 2), new Punkt(3, 4), new Punkt(5, 6));
            Console.WriteLine(tr);

            Obraz o = new Obraz();
            o.dodaj(tr);
            o.przesun(1,2);
        }
    }
}
