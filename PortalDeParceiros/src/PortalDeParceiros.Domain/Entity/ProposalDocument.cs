namespace PortalDeParceiros.Domain.Entity
{
    public class ProposalDocument
    {
        public enum Type
        {
            PersonalDocument,
            RegistrationForm
        }

        public int Id { get; set; }
        public string DocumentPath { get; set; }
        public Type DocumentType { get; set; }
        public Proposal Proposals { get; set; }
    }
}