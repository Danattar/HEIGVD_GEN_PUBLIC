package ch.heig.pl.lecteursredacteurs;

public class Redacteur {
    private boolean _isWaiting;
    private Controleur _controleur;

    public Redacteur(Controleur controleur) {
        _controleur = controleur;
    }

    public void startWrite() {
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

    public void stopWrite() {
        _controleur.isAvailable(true);
    }
}
