import java.util.ArrayList;
import java.util.Stack;
import org.xml.sax.Attributes;
import org.xml.sax.helpers.DefaultHandler;
import org.xml.sax.SAXException;

public class BookParserHandler extends DefaultHandler {
    // Liste à compléter en parsant le document XML
    private ArrayList bookList = new ArrayList();

    // à la lecture, les éléments XML seront empilés
    private Stack elementStack = new Stack();

    // lorsqu'un block est terminé, il est empilé
    private Stack objectStack = new Stack();

    public void startElement(String uri, String localName, String qName, Attributes attributes) throws SAXException
    {
        // mettre un élément dans le stack
        this.elementStack.push(qName);

        // si c'est le début d'un livre, préparer une instance Book
        if ("book".equals(qName)) {
            // nouvelle instance de Book
            Book user = new Book();

            // lecture de l'attribut si présent
            if(attributes != null && attributes.getLength() == 1) {
                user.setId(attributes.getValue(0));
            }
            this.objectStack.push(user);
        }
    }

    public void endElement(String uri, String localName, String qName) throws SAXException
    {
        // supprimer le dernier élément
        this.elementStack.pop();

        // l'instance Book est construite, la supprimer de la pile et la mettre dans la liste
        if ("book".equals(qName)) {
            Book object = (Book)this.objectStack.pop();
            this.bookList.add(object);
        }
    }

    // appelé pour chaque valeur de noeud
    public void characters(char[] ch, int start, int length) throws SAXException {
        String value = new String(ch, start, length).trim();
//todo switch
        // supprimer les espaces
        if (value.length() == 0) {
            return;
        }

        if("author".equals(currentElement())){
            Book user = (Book) this.objectStack.peek();
            user.setAuthor(value);
        }
        else if("title".equals(currentElement())){
            Book user = (Book) this.objectStack.peek();
            user.setTitle(value);
        }
        else if("genre".equals(currentElement())){
            Book user = (Book) this.objectStack.peek();
            user.setGenre(value);
        }
        else if("price".equals(currentElement())){
            Book user = (Book) this.objectStack.peek();
            user.setPrice(value);
        }
        else if("publish_date".equals(currentElement())){
            Book user = (Book) this.objectStack.peek();
            user.setPublishDate(value);
        }
        else if("description".equals(currentElement())){
            Book user = (Book) this.objectStack.peek();
            user.setDescription(value);
        }
    }

    // utile pour obtenir l'élément courant
    private String currentElement() {
        return this.elementStack.peek().toString();
    }

    // retourne la liste des livres
    public ArrayList getBooks() {
        return bookList;
    }
}