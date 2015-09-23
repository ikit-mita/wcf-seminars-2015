using System.Runtime.Serialization;

namespace SharedModel
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Login { get; set; }

        public string GetInitials()
        {
            return Name[0].ToString();
        }

        public override string ToString()
        {
            return string.Format("{0} [{1}]", Name, Login);
            //return $"{Name} [{Login}]";
        }
    }
}