using FC.Codeflix.Catalog.Application.UseCases.Category.ListCategories;
using MediatR;

namespace FC.Codeflix.Catalog.Application.UseCases.Category.GetCategory;
public interface IListCategories
    : IRequestHandler<ListCategoriesInput, ListCategoriesOutput>
{ }