#include <iostream>

using namespace std;

// базовый абстрактный напиток
class Beverage {
public:
    virtual ~Beverage() = default;
    virtual string getDescription() const = 0;
    virtual double getCost() const = 0;
};

// конкретный эспрессо
class Espresso : public Beverage {
public:
    string getDescription() const override {
        return "Espresso";
    }
    double getCost() const override {
        return 80.0;
    }
};

// конкретный американо
class Americano : public Beverage {
public:
    string getDescription() const override {
        return "Americano";
    }
    double getCost() const override {
        return 100.0;
    }
};

// абстрактный декоратор
class AdditiveDecorator : public Beverage {
protected:
    unique_ptr<Beverage> beverage;
public:
    AdditiveDecorator(unique_ptr<Beverage> b) : beverage(move(b)) {}
};

// конкретный для молока
class Milk : public AdditiveDecorator {
public:
    using AdditiveDecorator::AdditiveDecorator;
    string getDescription() const override {
        return beverage->getDescription() + ", Milk";
    }
    double getCost() const override {
        return beverage->getCost() + 20.0;
    }
};

// конкретный для сиропа
class Syrup : public AdditiveDecorator {
public:
    using AdditiveDecorator::AdditiveDecorator;
    string getDescription() const override {
        return beverage->getDescription() + ", Syrup";
    }
    double getCost() const override {
        return beverage->getCost() + 30.0;
    }
};

// конкретный для сахара
class Sugar : public AdditiveDecorator {
public:
    using AdditiveDecorator::AdditiveDecorator;
    string getDescription() const override {
        return beverage->getDescription() + ", Sugar";
    }
    double getCost() const override {
        return beverage->getCost() + 5.0;
    }
};

// пример без декоратора - американо с молоком и сиропом
class AmericanoWithMilkAndSyrup : public Americano {
public:
    string getDescription() const override {
        return Americano::getDescription() + ", Milk, Syrup";
    }
    double getCost() const override {
        return Americano::getCost() + 20.0 + 30.0;
    }
};

int main()
{
    unique_ptr<Beverage> firstCoffee = make_unique<Espresso>();
    unique_ptr<Beverage> secondCoffee = make_unique<Americano>();
    unique_ptr<Beverage> thirdCoffee = make_unique<Americano>();

    secondCoffee = make_unique<Milk>(move(secondCoffee));
    secondCoffee = make_unique<Sugar>(move(secondCoffee));

    thirdCoffee = make_unique<Syrup>(move(thirdCoffee));

    cout << "First coffee" << endl;
    cout << "Description: " << firstCoffee->getDescription() << endl;
    cout << "Cost: " << firstCoffee->getCost() << " rub" << endl << endl;

    cout << "Second coffee" << endl;
    cout << "Description: " << secondCoffee->getDescription() << endl;
    cout << "Cost: " << secondCoffee->getCost() << " rub" << endl << endl;

    cout << "Third coffee" << endl;
    cout << "Description: " << thirdCoffee->getDescription() << endl;
    cout << "Cost: " << thirdCoffee->getCost() << " rub" << endl << endl;
}
