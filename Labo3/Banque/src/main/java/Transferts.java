import ch.heig.pl.banque.Banque;

import java.util.concurrent.Callable;
import java.util.concurrent.ThreadLocalRandom;

public class Transferts implements Runnable {
    int _i = 0;
    int _nbTransferts;
    Banque _banque;

    public Transferts(int nbTranfserts, Banque banque){
        _nbTransferts = nbTranfserts;
        _banque = banque;
    }
    private int rand(int nbComptes) {
        return ThreadLocalRandom.current().nextInt(0, nbComptes);
    }

    public void run() {
        int nbComptes = _banque.getNbComptes();
        for (int i = 0; i < _nbTransferts; ++i) {
            _banque.transfert(rand(nbComptes), rand(nbComptes), rand(5));
            System.out.println(i);
        }

    }
}
