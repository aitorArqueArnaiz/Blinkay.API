using Blinkay.Infrastructure.Entities;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

public class UserMap : ClassMapping<User>
{
    public UserMap()
    {
        Id(x => x.Id, x =>
        {
            x.Generator(Generators.Increment);
            x.Type(NHibernateUtil.Int64);
            x.Column("iduser");
            x.UnsavedValue(0);
        });

        Property(b => b.Info, x =>
        {
            x.Length(500);
            x.Type(NHibernateUtil.StringClob);
            x.NotNullable(true);
        });

        Table("users");
    }
}