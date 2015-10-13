namespace Clients
{
    class TelephoneRecord
    {
        public string Telephone { get; set; }

        public string Face { get; set; }

        public string Appendix { get; set; }

        public void Fill(TelephoneRecord telephoneRecord)
        {
            Telephone = telephoneRecord.Telephone;
            Face = telephoneRecord.Face;
            Appendix = telephoneRecord.Appendix;
        }

    }
}
