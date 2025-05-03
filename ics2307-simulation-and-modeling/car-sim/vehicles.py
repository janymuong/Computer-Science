'''
vehicles simulation
author: prof waweru mwangi + janymuong
'''
import random


class Automobile:
    def __init__(self, make, model, mileage, price):
        self.__make = make
        self.__model = model
        self.__mileage = mileage
        self.__price = price
        self.color = self._random_color()
        self.width = random.randint(120, 200)
        self.height = random.randint(60, 100)
        self.wheel_radius = 15

    def _random_color(self):
        return "#{:06x}".format(random.randint(0, 0xFFFFFF))

    def randomize_visuals(self):
        self.color = self._random_color()
        self.width = random.randint(120, 200)
        self.height = random.randint(60, 100)

    # accessors and mutators
    def get_make(self): return self.__make
    def get_model(self): return self.__model
    def get_mileage(self): return self.__mileage
    def get_price(self): return self.__price
    def set_make(self, make): self.__make = make
    def set_model(self, model): self.__model = model
    def set_mileage(self, mileage): self.__mileage = mileage
    def set_price(self, price): self.__price = price

class Car(Automobile):
    def __init__(self, make, model, mileage, price, doors):
        super().__init__(make, model, mileage, price)
        self.__doors = doors
        self.roof_height = self.height // 2

    def get_doors(self): return self.__doors
    def set_doors(self, doors): self.__doors = doors

class Truck(Automobile):
    def __init__(self, make, model, mileage, price, drive_type):
        super().__init__(make, model, mileage, price)
        self.__drive_type = drive_type
        self.cargo_height = self.height // 3
        self.wheel_radius = 20  # larger wheels for trucks

    def get_drive_type(self): return self.__drive_type
    def set_drive_type(self, drive_type): self.__drive_type = drive_type

class SUV(Automobile):
    def __init__(self, make, model, mileage, price, pass_cap):
        super().__init__(make, model, mileage, price)
        self.__pass_cap = pass_cap
        self.roof_rack_height = 10

    def get_pass_cap(self): return self.__pass_cap
    def set_pass_cap(self, pass_cap): self.__pass_cap = pass_cap