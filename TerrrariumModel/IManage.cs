namespace TerrrariumModel
{
    public interface IManage
    {
        void Manage(IManagable imngbl);
    }

    public interface IManagable
    {
        void DoWork();
    }
}
