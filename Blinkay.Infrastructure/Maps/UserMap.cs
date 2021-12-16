using Blinkay.Infrastructure.Entities;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

public class UserMap : ClassMapping<User>
{
    public UserMap()
    {
        Id(x => x.iduser, x =>
        {
            x.Generator(Generators.Increment);
            x.Column("iduser");
        });

        Property(b => b.userinfo, x =>
        {
            x.Length(500);
            x.Column("userinfo");
            x.NotNullable(true);
        });

        Table("users");
    }
}