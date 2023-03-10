// See https://aka.ms/new-console-template for more information
internal class Program
{
    public enum Kelurahan
    {
        Batununggal, 
        Kujangsari,
        Mengger,
        Wates,
        Cijaura,
        Jatisari,
        Margasari,
        Sekejati,
        Kebonwaru,
        Maleer,
        Samoja
    }

    public class KodePos_1302213012
    {
        public static int getKodePos_1302213012(Kelurahan inKelurahan)
        {
            int[] outputKodePos = { 40266, 40287, 40267, 40256, 40287, 40286, 40286, 40286, 40272, 40274, 40273 };
            int inInt = (int)inKelurahan;
            return outputKodePos[inInt];
        }
    }

    private static void Main(string[] args)
    {
        KodePos_1302213012 KodeKel = new KodePos_1302213012();
        Kelurahan kelurahan = Kelurahan.Jatisari;
        int kodePos = KodePos_1302213012.getKodePos_1302213012(kelurahan);
        Console.WriteLine("Keluraha " + kelurahan + "\nKode Pos: " + kodePos);
    }
}
