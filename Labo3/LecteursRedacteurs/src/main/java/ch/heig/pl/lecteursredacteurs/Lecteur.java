package ch.heig.pl.lecteursredacteurs;

public class Lecteur {
    private boolean _isWaiting;
    private Controleur _controleur;

    public Lecteur(Controleur controleur) {
        _controleur = controleur;
    }

    public void startRead() {
        synchronized (_controleur) {
            while (!_controleur.isAvailable()) {
                _isWaiting = true;
                try {
                    this.wait();
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
        }
        _isWaiting = false;
        _controleur.isAvailable(false);
    }

    public boolean isWaiting() {
        return _isWaiting;
    }

    public void stopRead() {
        _controleur.isAvailable(true);
    }
}
