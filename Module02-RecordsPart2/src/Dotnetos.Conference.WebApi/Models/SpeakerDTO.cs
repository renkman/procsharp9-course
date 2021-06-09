using System.Text;

namespace Dotnetos.Conference.WebApi.Models
{
    public record SpeakerDTO(string FirstName, string LastName, string Company, bool PresentingOnline)
    {
        protected virtual bool PrintMembers(StringBuilder builder)
        {
            builder.Append(FirstName);
            builder.Append(" ");
            builder.Append(LastName);
            builder.Append(" (");
            builder.Append(Company);
            builder.Append("), presenting online: ");
            builder.Append(PresentingOnline);
            return true;
        }
        // public override string ToString() => $"{FirstName} {LastName} ({Company}), presenting online: {PresentingOnline}";
    }
}
