public class Main {

    interface Doc {
        void open();
    }

    static class WordDocs implements Doc {
        public void open() {
            System.out.println("Word Document...");
        }
    }

    static class PdfDocument implements Doc {
        public void open() {
            System.out.println("PDF Document...");
        }
    }

    static class ExcelDocument implements Doc {
        public void open() {
            System.out.println("Excel Document...");
        }
    }


    static abstract class DocumentFactory {
        public abstract Doc createDocument();
    }

    static class WordDocumentFactory extends DocumentFactory {
        public Doc createDocument() {
            return new WordDocs();
        }
    }

    static class PdfDocumentFactory extends DocumentFactory {
        public Doc createDocument() {
            return new PdfDocument();
        }
    }

    static class ExcelDocumentFactory extends DocumentFactory {
        public Doc createDocument() {
            return new ExcelDocument();
        }
    }
    public static void main(String[] args) {
        DocumentFactory wordFactory = new WordDocumentFactory();
        Doc word = wordFactory.createDocument();
        word.open();

        DocumentFactory pdfFactory = new PdfDocumentFactory();
        Doc pdf = pdfFactory.createDocument();
        pdf.open();

        DocumentFactory excelFactory = new ExcelDocumentFactory();
        Doc excel = excelFactory.createDocument();
        excel.open();
    }
}
