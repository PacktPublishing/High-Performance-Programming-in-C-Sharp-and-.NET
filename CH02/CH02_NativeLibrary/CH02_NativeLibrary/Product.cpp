#include <string>
#include <iostream>
#include <comdef.h>

struct Product {

	int Id;
	BSTR Name;

	void BuyProduct() {
		std::wcout << "Product.BuyProduct(" << Name << ");\n";
		std::cout << "Id: " << Id;
		std::cout << "\n";
	}
};

extern "C" __declspec(dllexport)  Product CreateProduct() {
	Product product = Product();
	product.Id = 1;
	product.Name = SysAllocString(L"New Product");
	return product;
}

extern "C" __declspec(dllexport) void BuyProduct(Product product) {
	product.BuyProduct();
}