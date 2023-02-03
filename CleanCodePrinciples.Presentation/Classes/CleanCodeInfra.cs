namespace CleanCodePrinciples.Presentation.Classes
{
    /// <summary>
    /// this class used instead of Core, Shared, ... and other layer in Onion Architecture
    /// </summary>
    public class CleanCodeInfra
    {
        public CleanCodeInfra()
        {

        }
        public CleanCodeInfra(Exception ex)
        {

        }
        public CleanCodeInfra SendMessage(string message)
        {
            //Send Message to Development Team
            return this;
        }
        public CleanCodeInfra DoLog()
        {
            //Write in Database or Physical File
            return this;
        }

        //....
    }

    public class DataLayerHasException : ApplicationException
    {
        private string _repositoryName;
        public DataLayerHasException(string msg,string RepositoryName) : base(msg)
        {
            this._repositoryName = RepositoryName;
        }

        public override string Message => $"{base.Message} \n Exception is triggered in Repository: {_repositoryName}.";
    }

    public readonly record struct CleanCodeRecordTemplate(int CleanCodeId, string CleanCodeName);

}