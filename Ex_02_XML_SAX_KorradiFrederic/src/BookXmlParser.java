import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;

import org.xml.sax.InputSource;
import org.xml.sax.SAXException;
import org.xml.sax.XMLReader;
import org.xml.sax.helpers.XMLReaderFactory;

public class BookXmlParser {
    public ArrayList parseXml(InputStream in) {
        //Create a empty link of users initially
        ArrayList<Book> users = new ArrayList<Book>();
        try {
            //create default handler instance
            BookParserHandler handler = new BookParserHandler();

            //create parser from factory
            XMLReader parser = XMLReaderFactory.createXMLReader();

            //register handler with parser
            parser.setContentHandler(handler);

            //create an input source from the XML input stream
            InputSource source = new InputSource(in);

            //parse the document
            parser.parse(source);

            //populate the parsed users list in above created empty list; You can return from here also.
            users = handler.getBooks();

        } catch (SAXException e) {
            e.printStackTrace();
        }

        catch (IOException e) {
            e.printStackTrace();
        }

        finally {
        }
        return users;
    }
}