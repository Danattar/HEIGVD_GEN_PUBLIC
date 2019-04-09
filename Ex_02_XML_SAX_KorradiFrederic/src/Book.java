public class Book {

    private static final int COLWIDTH = 12;
    private String _id, _author, _title, _genre, _price, _publishDate, _description;

    public void setId(String id) {_id = id;}
    public void setAuthor(String author){_author = author;}
    public void setTitle(String title){_title = title;}
    public void setPublishDate(String publishDate){_publishDate = publishDate;}
    public void setDescription(String description){_description = description;}
    public void setGenre(String genre){_genre = genre;}
    public void setPrice(String price){_price = price;}

    @Override
    public String toString() {

        StringBuilder builder = new StringBuilder();
        builder.append("------------------------------------- \n");
        builder.append(String.format("%-" + COLWIDTH + "s","id") + ": " + _id + "\n");
        builder.append(String.format("%-" + COLWIDTH + "s","title") + ": " + _title + "\n");
        builder.append(String.format("%-" + COLWIDTH + "s","author") + ": " + _author + "\n");
        builder.append(String.format("%-" + COLWIDTH + "s","genre") + ": " + _genre + "\n");
        builder.append(String.format("%-" + COLWIDTH + "s","price") + ": " + _price + "\n");
        builder.append(String.format("%-" + COLWIDTH + "s","description") + ": " + _description + "\n");
        builder.append(String.format("%-" + COLWIDTH + "s","published") + ": " + _publishDate + "\n");
        return builder.toString();
    }
}
