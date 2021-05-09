#include <string>
#include <iostream>
#include <comdef.h>

struct Shoe {
	int id;
	BSTR color;
	double size;
	BSTR brand;

	void buy() {
		std::cout << "Successfully purchased the ";
		std::wcout << color;
		std::wcout << " " << brand;
		std::cout << " shoe.";
	}
};

extern "C" __declspec(dllexport) void BuyShoe(Shoe shoe) {
	shoe.buy();
}


