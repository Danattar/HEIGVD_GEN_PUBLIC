package ch.heig.pl.lecteursredacteurs;

public class Lecteur {
    private boolean _isWaiting;
    private Controleur _controleur;

    public Lecteur(Controleur controleur) {
        _controleur = controleur;
    }

    public void startRead() {
        System.out.println("11");
        synchronized (_controleur) {
            System.out.println("12");
            while (!_controleur.isAvailable()) {
                System.out.println("13");
                _isWaiting = true;
                try {
                    System.out.println("10");
                    _controleur.wait();
                    System.out.println("2");
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
        }
        System.out.println("test");
        _isWaiting = false;

        _controleur.isAvailable(false);
    }

    public boolean isWaiting() {
        return _isWaiting;
    }

    public void stopRead() {
        System.out.println("3");
      //  _controleur.isAvailable(true);
      //  _controleur.notifyAll();
    //    notifyAll();
    }
}
