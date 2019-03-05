package ch.heig.pl.lecteursredacteurs;

public class Livre {
    private String _text = "Bon vieux livre des familles.";
    public void setText(String text){
        _text = text;
    }
    public String getText(){
        return _text;
    }

}
