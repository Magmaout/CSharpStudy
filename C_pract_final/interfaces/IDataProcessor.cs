namespace CSharpStudy.C_pract_final.interfaces {
    public interface IDataProcessor<T> {
        List<T> LoadData(string filePath);
        void SaveData(List<T> data, string filePath);
    }
}
