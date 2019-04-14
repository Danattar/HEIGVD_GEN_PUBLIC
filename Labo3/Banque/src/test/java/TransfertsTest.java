import ch.heig.pl.banque.Banque;
import ch.heig.pl.banque.Compte;

import static java.util.stream.LongStream.range;

class TransfertsTest {

    private static final int NBCOMPTES = 10;
    Banque[] _banques;
    Compte[] _comptes;


    @org.junit.jupiter.api.BeforeEach
    void setUp() {
        _banques = new Banque[1];
        _banques[0] = new Banque(NBCOMPTES);
    }

    @org.junit.jupiter.api.AfterEach
    void tearDown() {
    }

    @org.junit.jupiter.api.Test
    void Do_1000_tranferts_1000_times_KOT() {
        Thread t1 = new Thread(new Transferts(1000, _banques[0]));
        for (int i = 0; i < 1000; ++i) {
            t1.start();
        }

    }
}