package ch.heig.pl.lecteursredacteurs;

import static java.lang.Thread.sleep;

public class Controleur {

    private boolean _isAvailable = true;
    private Livre _livre = new Livre();

    public boolean isAvailable(){
        return _isAvailable;
    }

    public void isAvailable(boolean available){
        _isAvailable = available;
    }

    /*
    public void write() throws InterruptedException {
        _isAvailable = false;
        sleep(3000);
        _isAvailable = true;
    }
    public void read() throws InterruptedException {
        _isAvailable = false;
        sleep(3000);
        _isAvailable = true;
    }*/

}
