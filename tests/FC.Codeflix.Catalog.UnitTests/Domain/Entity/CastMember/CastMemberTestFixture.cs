using FC.Codeflix.Catalog.UnitTests.Common;
using DomainEntity = FC.Codeflix.Catalog.Domain.Entity;
using FC.Codeflix.Catalog.Domain.Enum;

namespace FC.Codeflix.Catalog.UnitTests.Domain.Entity.CastMember;

[CollectionDefinition(nameof(CastMemberTestFixture))]
public class CastMemberTestFixtureCollection
    : ICollectionFixture<CastMemberTestFixture>
{ }

public class CastMemberTestFixture
    : BaseFixture
{
    public DomainEntity.CastMember GetExampleCastMember()
        => new(
            GetValidName(),
            GetRandomCastMemberType()
        );

    public string GetValidName()
        => Faker.Name.FullName();

    public CastMemberType GetRandomCastMemberType()
        => (CastMemberType)(new Random()).Next(1, 2);
}