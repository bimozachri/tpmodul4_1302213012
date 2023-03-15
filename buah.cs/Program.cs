using System;

public class KodeBuah
{
    public enum buah { Apel, Aprikot, Alpukat, Pisang, Paprika, Blackberry, Ceri, Kelapa, Jagung, Kurma, Durian, Anggur, Melon, Semangka }
    public string[] buahKode = new string[] { "A00", "B00", "C00", "D00", "E00", "F00", "H00", "I00", "J00", "K00", "L00", "M00", "N00", "O00", };
    public KodeBuah()
    {
    }


    public void getKodeBuah(buah buha)
    {
        Console.WriteLine("Kode Buah: " + buahKode[(int)buha]);
    }
}

public class PosisiKarakterGame
{
    public enum Move { Jongkok, Berdiri, Tengkurap, Terbang }
    public enum Act { TombolW, TombolS, TombolX }

    public Move prev;
    public Move next;
    public Act act;

    public PosisiKarakterGame(Move prev, Move next, Act act)
    {
        this.prev = prev;
        this.next = next;
        this.act = act;
    }

    public PosisiKarakterGame[] game =
    {
        new PosisiKarakterGame(Move.Jongkok, Move.Tengkurap, Act.TombolS),
        new PosisiKarakterGame(Move.Tengkurap, Move.Jongkok, Act.TombolW),
        new PosisiKarakterGame(Move.Berdiri, Move.Jongkok, Act.TombolS),
        new PosisiKarakterGame(Move.Jongkok, Move.Berdiri, Act.TombolW),
        new PosisiKarakterGame(Move.Berdiri, Move.Terbang, Act.TombolS),
        new PosisiKarakterGame(Move.Terbang, Move.Jongkok, Act.TombolX),
    };

    public Move currentState;
    public Move moveList(Move prevState, Act actState)
    {
        for (int i = 0; i < game.Length; i++)
        {
            if (game[i].prev == prevState && game[i].act == actState)
            {
                currentState = game[i].next;
            }
        }
        return currentState;
    }

    public void Trigger(Act act)
    {
        Move Next = moveList(prev, act);
        Console.WriteLine(Next);
    }

    private static void Main(string[] args)
    {
        KodeBuah buah = new KodeBuah();
        buah.getKodeBuah(KodeBuah.buah.Apel);
        PosisiKarakterGame games = new PosisiKarakterGame(PosisiKarakterGame.Move.Jongkok, PosisiKarakterGame.Move.Tengkurap, PosisiKarakterGame.Act.TombolS);
        games.Trigger(PosisiKarakterGame.Act.TombolW);
    }
}