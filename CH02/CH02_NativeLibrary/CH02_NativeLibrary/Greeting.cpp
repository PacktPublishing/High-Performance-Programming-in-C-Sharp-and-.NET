#include <iostream>
#include <comdef.h>

extern "C" __declspec(dllexport) void SendGreeting();
extern "C" __declspec(dllexport) int Add(int, int);
extern "C" __declspec(dllexport) bool IsLengthGreaterThan5(const char*);
extern "C" __declspec(dllexport) BSTR GetName();

void SendGreeting() {
	std::cout << "Dear C#, C++ says hello!\n";
}

int Add(int x, int y) {
	return x + y;
}

bool IsLengthGreaterThan5(const char* value) {
	return strlen(value) > 5;
}

BSTR GetName() {
	return SysAllocString(L"Packt Publishing");
}