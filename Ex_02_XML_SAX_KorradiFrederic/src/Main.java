/// Sources : https://howtodoinjava.com/xml/sax-parser-read-xml-example/

import java.io.File;
import java.util.ArrayList;
import java.io.FileInputStream;
import java.io.FileNotFoundException;

public class Main {

    public static void main(String[] args) throws FileNotFoundException
    {
        //Locate the file
        File xmlFile = new File("src/book.xml");

        //Create the parser instance
        BookXmlParser parser = new BookXmlParser();

        //Parse the file
        ArrayList books = parser.parseXml(new FileInputStream(xmlFile));

        //Verify the result
        System.out.println(books);
    }
}