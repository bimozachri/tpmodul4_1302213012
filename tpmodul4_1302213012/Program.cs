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

    public enum DoorState
    {
        TERKUNCI, TERBUKA
    }

    public enum TriggerDoor
    {
        KUNCI_PINTU, BUKA_PINTU
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

    public class MechanicalDoor_1302213012
    {
        public DoorState currentState = DoorState.TERKUNCI;
        public class Transition
        {
            public DoorState stateAwal;
            public DoorState stateAkhir;
            public TriggerDoor trigger;

            public Transition(DoorState stateAwal, DoorState stateAkhir, TriggerDoor trigger)
            {
                this.stateAwal = stateAwal;
                this.stateAkhir = stateAkhir;
                this.trigger = trigger;
            }
        }
        Transition[] transitions = new Transition[]
        {
            new Transition(DoorState.TERKUNCI, DoorState.TERKUNCI, TriggerDoor.KUNCI_PINTU),
            new Transition(DoorState.TERKUNCI, DoorState.TERBUKA, TriggerDoor.BUKA_PINTU),
            new Transition(DoorState.TERBUKA, DoorState.TERBUKA, TriggerDoor.BUKA_PINTU),
            new Transition(DoorState.TERBUKA, DoorState.TERKUNCI, TriggerDoor.KUNCI_PINTU)
        };

        private DoorState getStateBerikutnya(DoorState stateAwal, TriggerDoor trigger)
        {
            DoorState stateAkhir = stateAwal;
            for(int i = 0; i < transitions.Length; i++)
            {
                Transition change = transitions[i];
                if(stateAwal == change.stateAwal && trigger == change.trigger)
                {
                    stateAkhir = change.stateAkhir;
                }
            }
            return stateAkhir;
        }
        public void triggerActive(TriggerDoor trigger)
        {
            currentState = getStateBerikutnya(currentState, trigger);
            Console.WriteLine("State yang sekarang " + currentState);
            if(currentState == DoorState.TERKUNCI)
            {
                Console.WriteLine("Pintu Terkunci");
            }else if(currentState == DoorState.TERBUKA)
            {
                Console.WriteLine("Pintu Terbuka");
            }
        }
    }

    private static void Main(string[] args)
    {
        KodePos_1302213012 KodeKel = new KodePos_1302213012();
        Kelurahan kelurahan = Kelurahan.Jatisari;
        int kodePos = KodePos_1302213012.getKodePos_1302213012(kelurahan);
        Console.WriteLine("Keluraha " + kelurahan + "\nKode Pos: " + kodePos);
        Console.WriteLine();

        MechanicalDoor_1302213012 door = new MechanicalDoor_1302213012();
        door.triggerActive(TriggerDoor.KUNCI_PINTU);
        door.triggerActive(TriggerDoor.BUKA_PINTU);
        door.triggerActive(TriggerDoor.KUNCI_PINTU);
        door.triggerActive(TriggerDoor.BUKA_PINTU);
    }
}
