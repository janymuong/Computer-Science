#!/usr/bin/env python3

'''
SCT211-0848/2018 - Jany Muong
ICS 2307: Simulation and Modeling

module: car-simulation
a stochastic vehicle simulation with 3 vehicle types (Saloon Car, Truck, SUV)
that generates random designs with each click

core concept: stochastic generation of all visual components - using randomization engine
'''
import tkinter as tk
import random
import math
from tkinter import ttk
from vehicles import Car, SUV, Truck
from flowers import FlowerGenerator


class CarInventorySimulation:
    def __init__(self, root):
        self.root = root
        self.root.title("Jany Muong's Car Simulation")
        self.root.geometry("1800x1200")  # Increased window size
        
        # Initialize flower generator
        self.flower_gen = FlowerGenerator()
        
        # style configuration
        self.style = ttk.Style()
        self.style.configure('TNotebook.Tab', padding=[20, 5], font=('Arial', 10, 'bold'))
        self.style.configure('TButton', font=('Arial', 10), padding=5)
        
        # Create main frame with border
        self.main_frame = tk.Frame(root, bd=5, relief=tk.RIDGE, bg="#f0f0f0")
        self.main_frame.pack(fill=tk.BOTH, expand=True, padx=10, pady=10)
        
        # create notebook with tabs inside main frame
        self.notebook = ttk.Notebook(self.main_frame)
        self.notebook.pack(fill=tk.BOTH, expand=True, padx=5, pady=5)
        
        # create frames for each vehicle type
        self.car_frame = ttk.Frame(self.notebook, padding=10)
        self.truck_frame = ttk.Frame(self.notebook, padding=10)
        self.suv_frame = ttk.Frame(self.notebook, padding=10)
        
        self.notebook.add(self.car_frame, text="Saloon Car")
        self.notebook.add(self.truck_frame, text="Truck")
        self.notebook.add(self.suv_frame, text="SUV")
        
        # setup each tab
        self.setup_car_tab()
        self.setup_truck_tab()
        self.setup_suv_tab()
        
        # initialize vehicle objects
        self.current_car = None
        self.current_truck = None
        self.current_suv = None
    
    def setup_car_tab(self):
        # main container frame
        main_frame = tk.Frame(self.car_frame)
        main_frame.pack(fill=tk.BOTH, expand=True)
        
        # left frame for canvas
        left_frame = tk.Frame(main_frame)
        left_frame.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)
        
        # right frame for attributes (positioned at top right)
        right_frame = tk.Frame(main_frame, width=400, height=300, bd=2, relief=tk.RIDGE)
        right_frame.pack(side=tk.RIGHT, fill=tk.Y, padx=10, pady=10)
        
        # Frame for controls (positioned at top)
        control_frame = tk.Frame(left_frame, bd=2, relief=tk.RIDGE)
        control_frame.pack(fill=tk.X, pady=(0, 15))
        
        # create button
        self.car_button = ttk.Button(control_frame, text="Generate Random Car", 
                                   command=self.draw_random_car, style='TButton')
        self.car_button.pack(side=tk.LEFT, padx=10, pady=5)
        
        # create canvas
        self.car_canvas = tk.Canvas(left_frame, bg="white", width=1200, height=700)
        self.car_canvas.pack(fill=tk.BOTH, expand=True, padx=10, pady=10)
        
        # create text widget for attributes
        self.car_attributes = tk.Text(right_frame, height=15, width=45, wrap=tk.WORD,
                                    font=('Arial', 10), bg='#f0f0f0', relief=tk.FLAT)
        self.car_attributes.pack(fill=tk.BOTH, expand=True, padx=10, pady=10)
        self.car_attributes.config(state=tk.DISABLED)
        
        # Initial draw
        self.draw_random_car()
    
    def setup_truck_tab(self):
        # tab for truck
        main_frame = tk.Frame(self.truck_frame)
        main_frame.pack(fill=tk.BOTH, expand=True)
        
        left_frame = tk.Frame(main_frame)
        left_frame.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)
        
        right_frame = tk.Frame(main_frame, width=400, height=300, bd=2, relief=tk.RIDGE)
        right_frame.pack(side=tk.RIGHT, fill=tk.Y, padx=10, pady=10)
        
        control_frame = tk.Frame(left_frame, bd=2, relief=tk.RIDGE)
        control_frame.pack(fill=tk.X, pady=(0, 15))
        
        self.truck_button = ttk.Button(control_frame, text="Generate Random Truck", 
                                     command=self.draw_random_truck, style='TButton')
        self.truck_button.pack(side=tk.LEFT, padx=10, pady=5)
        
        self.truck_canvas = tk.Canvas(left_frame, bg="white", width=1200, height=700)
        self.truck_canvas.pack(fill=tk.BOTH, expand=True, padx=10, pady=10)
        
        self.truck_attributes = tk.Text(right_frame, height=15, width=45, wrap=tk.WORD,
                                      font=('Arial', 10), bg='#f0f0f0', relief=tk.FLAT)
        self.truck_attributes.pack(fill=tk.BOTH, expand=True, padx=10, pady=10)
        self.truck_attributes.config(state=tk.DISABLED)
        
        self.draw_random_truck()
    
    def setup_suv_tab(self):
        # tab for suv
        main_frame = tk.Frame(self.suv_frame)
        main_frame.pack(fill=tk.BOTH, expand=True)
        
        left_frame = tk.Frame(main_frame)
        left_frame.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)
        
        right_frame = tk.Frame(main_frame, width=400, height=300, bd=2, relief=tk.RIDGE)
        right_frame.pack(side=tk.RIGHT, fill=tk.Y, padx=10, pady=10)
        
        control_frame = tk.Frame(left_frame, bd=2, relief=tk.RIDGE)
        control_frame.pack(fill=tk.X, pady=(0, 15))
        
        self.suv_button = ttk.Button(control_frame, text="Generate Random Volvo SUV", 
                                   command=self.draw_random_suv, style='TButton')
        self.suv_button.pack(side=tk.LEFT, padx=10, pady=5)
        
        self.suv_canvas = tk.Canvas(left_frame, bg="white", width=1200, height=700)
        self.suv_canvas.pack(fill=tk.BOTH, expand=True, padx=10, pady=10)
        
        self.suv_attributes = tk.Text(right_frame, height=15, width=45, wrap=tk.WORD,
                                    font=('Arial', 10), bg='#f0f0f0', relief=tk.FLAT)
        self.suv_attributes.pack(fill=tk.BOTH, expand=True, padx=10, pady=10)
        self.suv_attributes.config(state=tk.DISABLED)
        
        self.draw_random_suv()

    def random_color(self):
        """Generate a random color in hex format"""
        r = random.randint(0, 255)
        g = random.randint(0, 255)
        b = random.randint(0, 255)
        return f"#{r:02x}{g:02x}{b:02x}"

    def draw_random_car(self):
        self.car_canvas.delete("all")
        
        # draw frame with roses at the bottom
        self.draw_frame_with_bottom_roses(self.car_canvas, 1200, 700)
        
        # Create random car object with more stochastic parameters
        self.current_car = Car(
            make='BMW',
            model='2001',
            mileage=70000,
            price=15000.0,
            doors=4
        )
        
        # random visual properties
        car_color = self.random_color()  # BMW common colors
        wheel_color = "#222222"  # dark wheels to make it look wheel
        car_length = random.randint(450, 900)  # BMW series
        car_height = random.randint(150, 200)  # Lower profile
        wheel_size = random.randint(35, 45)    # Larger wheels
        
        # fixed position in upper middle part of canvas
        center_x = 600
        center_y = 250
        
        # BMW series specific styling
        body_points = [
            center_x - car_length/2 + 30, center_y - car_height/4,
            center_x - car_length/2, center_y,
            center_x - car_length/2, center_y + car_height/2,
            center_x + car_length/2, center_y + car_height/2,
            center_x + car_length/2, center_y,
            center_x + car_length/2 - 30, center_y - car_height/4,
            center_x + car_length/2 - 60, center_y - car_height/2,
            center_x - car_length/2 + 60, center_y - car_height/2
        ]
        self.car_canvas.create_polygon(body_points, fill=car_color, outline="black", width=2, smooth=True)
        
        # Roof with BMW's signature Hofmeister kink
        roof_width = car_length * 0.7
        roof_points = [
            center_x - roof_width/2, center_y - car_height/2,
            center_x - roof_width/4, center_y - car_height/2 - car_height/3,
            center_x + roof_width/4, center_y - car_height/2 - car_height/3,
            center_x + roof_width/2, center_y - car_height/2,
            center_x + roof_width/2 - 20, center_y - car_height/3,  # Hofmeister kink
            center_x - roof_width/2 + 20, center_y - car_height/3
        ]
        self.car_canvas.create_polygon(roof_points, fill=car_color, outline="black", width=2, smooth=True)
        
        # windows with BMW signature design
        window_points = [
            center_x - roof_width/3, center_y - car_height/2 + 5,
            center_x - roof_width/4 + 10, center_y - car_height/2 - car_height/4,
            center_x + roof_width/4 - 10, center_y - car_height/2 - car_height/4,
            center_x + roof_width/3, center_y - car_height/2 + 5,
            center_x + roof_width/3 - 20, center_y - car_height/3 + 5,  # Follows kink
            center_x - roof_width/3 + 20, center_y - car_height/3 + 5
        ]
        self.car_canvas.create_polygon(window_points, fill=self.random_glass_color(), outline="black", width=1)
        

        
        self.car_canvas.create_line(
            center_x, center_y - car_height/2 + 5,
            center_x, center_y - car_height/3 - 5,
            fill="black", width=1
        )

        # line to show 2 doors from my pov(2 others on other side)
        self.car_canvas.create_line(
            center_x, center_y - car_height/4,
            center_x, center_y + car_height/4,
            fill="black", width=2
        )

        # clear 4-door separator
        self.car_canvas.create_line(
            center_x - car_length/4, center_y - car_height/4,
            center_x - car_length/4, center_y + car_height/4,
            fill="black", width=2
        )
        self.car_canvas.create_line(
            center_x + car_length/4, center_y - car_height/4,
            center_x + car_length/4, center_y + car_height/4,
            fill="black", width=2
        )
        # small lines to indicate door handles
        self.car_canvas.create_line(
            center_x - car_length/4 + 10, center_y,
            center_x - car_length/4 + 20, center_y,
            fill="black", width=2
        )
        self.car_canvas.create_line(
            center_x + car_length/4 - 20, center_y,
            center_x + car_length/4 - 10, center_y,
            fill="black", width=2
        )
        
        # grille
        grill_width = 80
        grill_height = 30
        self.car_canvas.create_rectangle(
            center_x - car_length/2 + 50, center_y - car_height/4,
            center_x - car_length/2 + 50 + grill_width, center_y - car_height/4 + grill_height,
            fill="#333333", outline="black", width=1
        )
        # vertical grille lines
        for i in range(1, 8):
            x_pos = center_x - car_length/2 + 50 + i * grill_width/8
            self.car_canvas.create_line(
                x_pos, center_y - car_height/4,
                x_pos, center_y - car_height/4 + grill_height,
                fill="silver", width=2
            )
        
        # BMW roundel logo
        self.car_canvas.create_oval(
            center_x - car_length/2 + 70, center_y - car_height/4 - 15,
            center_x - car_length/2 + 110, center_y - car_height/4 + 25,
            fill="#0066B1", outline="black", width=1
        )
        self.car_canvas.create_oval(
            center_x - car_length/2 + 75, center_y - car_height/4 - 10,
            center_x - car_length/2 + 105, center_y - car_height/4 + 20,
            fill="white", outline="black", width=1
        )
        
        # wheels
        wheel_y = center_y + car_height/2 - wheel_size/3
        wheel_spread = 0.3 * car_length
        
        # left wheel
        left_wheel_x = center_x - wheel_spread
        self.draw_bmw_wheel(self.car_canvas, left_wheel_x, wheel_y, wheel_size, wheel_color)
        
        # right wheel
        right_wheel_x = center_x + wheel_spread
        self.draw_bmw_wheel(self.car_canvas, right_wheel_x, wheel_y, wheel_size, wheel_color)
        
        # headlights - laser lights
        headlight_points = [
            center_x - car_length/2 + 10, center_y - car_height/6,
            center_x - car_length/2 + 40, center_y - car_height/8,
            center_x - car_length/2 + 40, center_y + car_height/8,
            center_x - car_length/2 + 10, center_y + car_height/6
        ]
        self.car_canvas.create_polygon(headlight_points, fill="#bbddff", outline="black", width=1)
        
        # taillights - L-shaped
        taillight_points = [
            center_x + car_length/2 - 10, center_y - car_height/6,
            center_x + car_length/2, center_y - car_height/8,
            center_x + car_length/2, center_y + car_height/8,
            center_x + car_length/2 - 10, center_y + car_height/6
        ]
        self.car_canvas.create_polygon(taillight_points, fill="#ff3333", outline="black", width=1)
        self.car_canvas.create_rectangle(
            center_x + car_length/2 - 15, center_y - car_height/8,
            center_x + car_length/2 - 10, center_y + car_height/8,
            fill="#ff3333", outline="black", width=1
        )
        
        # side vents (BMW signature)
        self.car_canvas.create_rectangle(
            center_x - car_length/4, center_y,
            center_x - car_length/4 + 50, center_y + 10,
            fill="#333333", outline="black", width=1
        )
        
        # display car attributes
        self.display_vehicle_attributes(self.car_attributes, self.current_car)
    
    def draw_random_truck(self):
        self.truck_canvas.delete("all")
        
        # Draw frame with roses at the bottom
        self.draw_frame_with_bottom_roses(self.truck_canvas, 1200, 700)
        
        # Create random truck object with more stochastic parameters
        # 2002, 40000, 12000.0, '4WD'
        make = 'Toyota'
        model = '2002'
        mileage = 40000
        drive_type = '4WD'
        price = 12000.0
        self.current_truck = Truck(
            make, model, mileage, price, drive_type
        )
    
        # visual properties - toyota truck style
        # truck_color = random.choice(["#B5121B", "#000000", "#7D848A", "#FFFFFF"])  # Toyota colors
        truck_color = self.random_color()  # Toyota colors
        cabin_color = truck_color
        wheel_color = "#222222"
        truck_length = random.randint(550, 800)  # Longer trucks
        truck_height = random.randint(180, 250)  # Taller
        wheel_size = random.randint(40, 50)     # Larger wheels
        
        # fixed position in upper middle part of canvas
        center_x = 600
        center_y = 250
        
        # toyota truck proportions
        bed_length_ratio = random.uniform(0.5, 0.6)
        cabin_height_ratio = 1.2
        
        # draw truck bed
        bed_length = truck_length * bed_length_ratio
        bed_height = truck_height * 0.8
        
        self.truck_canvas.create_rectangle(
            center_x, 
            center_y - bed_height/2,
            center_x + bed_length, 
            center_y + bed_height/2,
            fill=truck_color, outline="black", width=2
        )
        
        # Toyota logo on tailgate
        self.truck_canvas.create_oval(
            center_x + bed_length - 40, center_y - 20,
            center_x + bed_length - 10, center_y + 10,
            fill="#EB0A1E", outline="black", width=1
        )
        
        # draw cabin with Toyota styling
        cabin_length = truck_length - bed_length
        cabin_height = truck_height * cabin_height_ratio
        
        # cabin front with Toyota's trapezoidal grille shape
        cabin_points = [
            center_x - cabin_length, center_y - bed_height/2,
            center_x - cabin_length, center_y - cabin_height/2,
            center_x - cabin_length * 0.7, center_y - cabin_height/2 - cabin_height/4,
            center_x - cabin_length * 0.3, center_y - cabin_height/2 - cabin_height/4,
            center_x, center_y - cabin_height/2,
            center_x, center_y - bed_height/2
        ]
        self.truck_canvas.create_polygon(cabin_points, fill=cabin_color, outline="black", width=2)
        
        # cabin side
        self.truck_canvas.create_rectangle(
            center_x - cabin_length, 
            center_y - bed_height/2,
            center_x, 
            center_y + bed_height/2,
            fill=cabin_color, outline="black", width=2
        )
        
        # truck window
        window_points = [
            center_x - cabin_length + 20, center_y - cabin_height/2 + 10,
            center_x - cabin_length * 0.6, center_y - cabin_height/2 - cabin_height/6 + 10,
            center_x - 10, center_y - cabin_height/2 + 10,
            center_x - 10, center_y - cabin_height/2 + 60,
            center_x - cabin_length + 20, center_y - cabin_height/2 + 60
        ]
        self.truck_canvas.create_polygon(window_points, fill=self.random_glass_color(), outline="black", width=1)
        
        # toyota emblem on grille
        self.truck_canvas.create_oval(
            center_x - cabin_length + 40, center_y - cabin_height/4 - 15,
            center_x - cabin_length + 80, center_y - cabin_height/4 + 15,
            fill="#FFFFFF", outline="black", width=1
        )
        
        # draw wheels with Toyota truck style
        wheel_y = center_y + bed_height/2 - wheel_size/3
        
        # front wheel
        front_wheel_x = center_x - cabin_length * 0.5
        self.draw_truck_wheel(self.truck_canvas, front_wheel_x, wheel_y, wheel_size, wheel_color)
        
        # rear wheels (dual wheels)
        rear_wheel_x = center_x + bed_length * 0.3
        self.draw_truck_wheel(self.truck_canvas, rear_wheel_x, wheel_y, wheel_size, wheel_color)
        self.draw_truck_wheel(self.truck_canvas, rear_wheel_x + wheel_size * 0.8, wheel_y, wheel_size, wheel_color)
        
        rear_wheel_x2 = center_x + bed_length * 0.7
        self.draw_truck_wheel(self.truck_canvas, rear_wheel_x2, wheel_y, wheel_size, wheel_color)
        self.draw_truck_wheel(self.truck_canvas, rear_wheel_x2 + wheel_size * 0.8, wheel_y, wheel_size, wheel_color)
        
        # Toyota truck headlights
        self.truck_canvas.create_rectangle(
            center_x - cabin_length + 10, center_y - cabin_height/4,
            center_x - cabin_length + 30, center_y + cabin_height/8,
            fill="#ffff99", outline="black", width=1
        )
        
        # Toyota truck taillights
        self.truck_canvas.create_rectangle(
            center_x + bed_length - 20, center_y - bed_height/4,
            center_x + bed_length, center_y + bed_height/8,
            fill="#ff3333", outline="black", width=1
        )
        
        # display truck attributes
        self.display_vehicle_attributes(self.truck_attributes, self.current_truck)
    
    def draw_random_suv(self):
        self.suv_canvas.delete("all")
        
        # draw frame with roses at the bottom
        self.draw_frame_with_bottom_roses(self.suv_canvas, 1200, 700)
        
        # create random SUV object with more stochastic parameters
        self.current_suv = SUV(
            make='Volvo',
            model='2000',
            mileage=30000,
            price=18500.0,
            pass_cap=5
        )
        
        # volvo SUV styling
        suv_color = self.random_color()
        wheel_color = "#222222"
        suv_length = random.randint(600, 700)
        suv_height = random.randint(150, 270)
        wheel_size = random.randint(35, 45)
        
        # Fixed position in upper middle part of canvas
        center_x = 600
        center_y = 250
        
        # Main body with more refined Volvo XC90-like shape
        body_points = [
            # Front points
            center_x - suv_length/2 + 50, center_y - suv_height/2 + 10,
            center_x - suv_length/2 + 30, center_y - suv_height/3,
            center_x - suv_length/2, center_y,
            # Bottom front to rear
            center_x - suv_length/2, center_y + suv_height/2 - 10,
            # Rear wheel arch
            center_x - suv_length/4, center_y + suv_height/2,
            center_x + suv_length/4, center_y + suv_height/2,
            # Bottom rear to front
            center_x + suv_length/2, center_y + suv_height/2 - 10,
            center_x + suv_length/2, center_y,
            # Top rear to front
            center_x + suv_length/2 - 30, center_y - suv_height/3,
            center_x + suv_length/2 - 50, center_y - suv_height/2 + 10,
        ]
        self.suv_canvas.create_polygon(body_points, fill=suv_color, outline="black", width=2, smooth=True)
        
        # Volvo's "Thor's Hammer" headlight design (more detailed)
        headlight_points = [
            center_x - suv_length/2 + 10, center_y - suv_height/4,
            center_x - suv_length/2 + 40, center_y - suv_height/6,
            center_x - suv_length/2 + 40, center_y,
            center_x - suv_length/2 + 10, center_y + suv_height/6
        ]
        self.suv_canvas.create_polygon(headlight_points, fill="#ffffff", outline="black", width=1)
        
        # Headlight details (LED elements)
        for i in range(3):
            y_pos = center_y - suv_height/6 + i*10
            self.suv_canvas.create_line(
                center_x - suv_length/2 + 15, y_pos,
                center_x - suv_length/2 + 35, y_pos,
                fill="yellow", width=1
            )
        
        # Volvo's signature grille with more detail
        grille_width = 50
        grille_height = 30
        grille_x = center_x - suv_length/2 + 50
        grille_y = center_y - suv_height/3
        
        self.suv_canvas.create_rectangle(
            grille_x, grille_y,
            grille_x + grille_width, grille_y + grille_height,
            fill="#333333", outline="black", width=1
        )
        
        # Diagonal Volvo bar with 3D effect
        for i in range(3):
            self.suv_canvas.create_line(
                grille_x + i*5, grille_y + grille_height/2 - i*2,
                grille_x + grille_width - i*5, grille_y + grille_height/2 - i*2,
                fill="silver", width=2
            )
        
        # Volvo iron mark logo (more detailed)
        logo_x = grille_x + 20
        logo_y = grille_y + grille_height/2
        self.suv_canvas.create_line(
            logo_x, logo_y - 10,
            logo_x, logo_y + 10,
            fill="silver", width=3
        )
        self.suv_canvas.create_line(
            logo_x, logo_y,
            logo_x + 10, logo_y - 10,
            fill="silver", width=3
        )
        self.suv_canvas.create_line(
            logo_x, logo_y,
            logo_x + 10, logo_y + 10,
            fill="silver", width=3
        )
        self.suv_canvas.create_text(
            logo_x + 25, logo_y,
            text="VOLVO", font=("Arial", 8, "bold"),
            fill="silver", anchor="w"
        )
        
        # Windows with more realistic shape and details
        window_points = [
            center_x - suv_length/2 + 50, center_y - suv_height/2 + 20,
            center_x - suv_length/4, center_y - suv_height/3 + 5,
            center_x + suv_length/4, center_y - suv_height/3 + 5,
            center_x + suv_length/2 - 50, center_y - suv_height/2 + 20,
            center_x + suv_length/2 - 50, center_y - 10,
            center_x - suv_length/2 + 50, center_y - 10
        ]
        self.suv_canvas.create_polygon(window_points, fill=self.random_glass_color(), outline="black", width=1)
        
        # Window divider
        self.suv_canvas.create_line(
            center_x, center_y - suv_height/3 + 5,
            center_x, center_y - 10,
            fill="black", width=1
        )
        
        # Wheels - more detailed Volvo style
        wheel_y = center_y + suv_height/2 - wheel_size/3
        wheel_spread = 0.3 * suv_length
        
        # front wheel
        front_wheel_x = center_x - wheel_spread
        self.draw_volvo_wheel(self.suv_canvas, front_wheel_x, wheel_y, wheel_size, wheel_color)
        
        # rear wheel
        rear_wheel_x = center_x + wheel_spread
        self.draw_volvo_wheel(self.suv_canvas, rear_wheel_x, wheel_y, wheel_size, wheel_color)
        
        # Volvo's vertical taillights with LED pattern
        taillight_height = suv_height/2
        taillight_x = center_x + suv_length/2 - 20
        
        self.suv_canvas.create_rectangle(
            taillight_x, center_y - taillight_height/4,
            taillight_x + 20, center_y + taillight_height/4,
            fill="#ff3333", outline="black", width=1
        )
        
        # Taillight details
        for i in range(5):
            y_pos = center_y - taillight_height/4 + i*(taillight_height/2)/5
            self.suv_canvas.create_line(
                taillight_x + 5, y_pos + 2,
                taillight_x + 15, y_pos + 2,
                fill="#ff6666", width=1
            )
        
        # Roof rails with end caps
        self.suv_canvas.create_line(
            center_x - suv_length/2 + 50, center_y - suv_height/2 - 5,
            center_x + suv_length/2 - 50, center_y - suv_height/2 - 5,
            fill="#333333", width=4
        )
        # Rail end caps
        for x in [center_x - suv_length/2 + 50, center_x + suv_length/2 - 50]:
            self.suv_canvas.create_oval(
                x - 5, center_y - suv_height/2 - 10,
                x + 5, center_y - suv_height/2,
                fill="#333333", outline="black"
            )
        
        # Character line (side body crease)
        self.suv_canvas.create_line(
            center_x - suv_length/2 + 50, center_y - 5,
            center_x - suv_length/4, center_y - 10,
            center_x + suv_length/4, center_y - 10,
            center_x + suv_length/2 - 50, center_y - 5,
            fill="#666666", width=2, smooth=True
        )
        
        # Door handles
        handle_y = center_y + 5
        for handle_x in [center_x - suv_length/4, center_x + suv_length/4]:
            self.suv_canvas.create_rectangle(
                handle_x - 15, handle_y - 3,
                handle_x - 5, handle_y + 3,
                fill=suv_color, outline="#666666", width=1
            )
        
        # Side mirrors
        mirror_points = [
            center_x - suv_length/2 + 40, center_y - suv_height/3,
            center_x - suv_length/2 + 20, center_y - suv_height/4,
            center_x - suv_length/2 + 20, center_y - suv_height/6,
            center_x - suv_length/2 + 40, center_y - suv_height/6
        ]
        self.suv_canvas.create_polygon(mirror_points, fill=suv_color, outline="black", width=1)
        
        # Right side mirror
        mirror_points = [
            center_x + suv_length/2 - 40, center_y - suv_height/3,
            center_x + suv_length/2 - 20, center_y - suv_height/4,
            center_x + suv_length/2 - 20, center_y - suv_height/6,
            center_x + suv_length/2 - 40, center_y - suv_height/6
        ]
        self.suv_canvas.create_polygon(mirror_points, fill=suv_color, outline="black", width=1)
        
        # display SUV attributes
        self.display_vehicle_attributes(self.suv_attributes, self.current_suv)
    
    def draw_bmw_wheel(self, canvas, x, y, size, color):
        """Draw a BMW style wheel"""
        # Tire
        canvas.create_oval(
            x - size, y - size,
            x + size, y + size,
            fill="#333333", outline="black", width=2
        )
        
        # rim
        rim_size = size * 0.7
        canvas.create_oval(
            x - rim_size, y - rim_size,
            x + rim_size, y + rim_size,
            fill="silver", outline="black", width=1
        )
        
        # BMW spoke pattern
        for i in range(5):
            angle = math.radians(i * 72)
            end_x = x + rim_size * 0.9 * math.cos(angle)
            end_y = y + rim_size * 0.9 * math.sin(angle)
            canvas.create_line(x, y, end_x, end_y, fill="#222222", width=3)
        
        # center cap
        hub_size = size * 0.2
        canvas.create_oval(
            x - hub_size, y - hub_size,
            x + hub_size, y + hub_size,
            fill="#0066B1", outline="black", width=1
        )
        canvas.create_oval(
            x - hub_size*0.7, y - hub_size*0.7,
            x + hub_size*0.7, y + hub_size*0.7,
            fill="white", outline="black", width=1
        )
    
    def draw_truck_wheel(self, canvas, x, y, size, color):
        """Draw a truck style wheel"""
        # Outer tire
        canvas.create_oval(
            x - size, y - size,
            x + size, y + size,
            fill="#333333", outline="black", width=2
        )
        
        # rim
        rim_size = size * 0.6
        canvas.create_oval(
            x - rim_size, y - rim_size,
            x + rim_size, y + rim_size,
            fill="#666666", outline="black", width=1
        )
        
        # spokes (heavy duty)
        for i in range(6):
            angle = math.radians(i * 60)
            end_x = x + rim_size * 0.8 * math.cos(angle)
            end_y = y + rim_size * 0.8 * math.sin(angle)
            canvas.create_line(x, y, end_x, end_y, fill="#222222", width=3)
        
        # hub
        hub_size = size * 0.3
        canvas.create_oval(
            x - hub_size, y - hub_size,
            x + hub_size, y + hub_size,
            fill="#222222", outline="black", width=1
        )
    
    def draw_volvo_wheel(self, canvas, x, y, size, color):
        """Draw a Volvo style wheel"""
        # tire
        canvas.create_oval(
            x - size, y - size,
            x + size, y + size,
            fill="#333333", outline="black", width=2
        )
        
        # rim
        rim_size = size * 0.75
        canvas.create_oval(
            x - rim_size, y - rim_size,
            x + rim_size, y + rim_size,
            fill="silver", outline="black", width=1
        )
        
        # volvo's signature 5-spoke design
        for i in range(5):
            angle = math.radians(i * 72)
            end_x = x + rim_size * 0.9 * math.cos(angle)
            end_y = y + rim_size * 0.9 * math.sin(angle)
            canvas.create_line(x, y, end_x, end_y, fill="#222222", width=4)
        
        # Center cap with Volvo logo
        hub_size = size * 0.2
        canvas.create_oval(
            x - hub_size, y - hub_size,
            x + hub_size, y + hub_size,
            fill="#333333", outline="black", width=1
        )
        canvas.create_line(
            x - hub_size*0.5, y,
            x + hub_size*0.5, y,
            fill="silver", width=3
        )
        canvas.create_line(
            x, y - hub_size*0.5,
            x, y + hub_size*0.5,
            fill="silver", width=3
        )
    
    def display_vehicle_attributes(self, text_widget, vehicle):
        """Display vehicle attributes in the text widget"""
        if isinstance(vehicle, Car):
            vehicle_type = "Saloon Car"
            specific_attr = f"Number of Doors: {vehicle.get_doors()}"
        elif isinstance(vehicle, Truck):
            vehicle_type = "Truck"
            specific_attr = f"Drive Type: {vehicle.get_drive_type()}"
        elif isinstance(vehicle, SUV):
            vehicle_type = "SUV"
            specific_attr = f"Passenger Capacity: {vehicle.get_pass_cap()}"
        else:
            return
        
        # enable writing to the text widget
        text_widget.config(state=tk.NORMAL)
        text_widget.delete(1.0, tk.END)
        
        # Create the attribute text
        attributes = [
            f"Used Car Inventory/ Parking Lot",
            f"{31 * '='}",
            f"The following {vehicle_type} is in Inventory:\n",
            f"Make: {vehicle.get_make()}",
            f"Model: {vehicle.get_model()}",
            f"Mileage: {vehicle.get_mileage():,} miles",
            f"Price: {vehicle.get_price():,.2f}",
            specific_attr,
            f"{31 * '='}",
            # f"Color: {vehicle.color}",
        ]
        
        # Insert the attributes with formatting
        text_widget.tag_configure("title", font=('Arial', 12, 'bold'), foreground='#333333')
        text_widget.tag_configure("attr", font=('Arial', 10), foreground='#555555')
        
        text_widget.insert(tk.END, attributes[0] + "\n", "title")
        for attr in attributes[1:]:
            text_widget.insert(tk.END, attr + "\n", "attr")
        
        # Make it read-only again
        text_widget.config(state=tk.DISABLED)
    
    def draw_frame_with_bottom_roses(self, canvas, width, height, padding=20):
        """draw decorative frame with 6 roses at the bottom"""
        # draw decorative frame
        frame_color = "#5D4037"  # Consistent dark brown frame
        canvas.create_rectangle(
            padding, padding,
            width - padding, height - padding,
            outline=frame_color, width=4, dash=(4, 4))
        
        # Fixed positions for 6 roses at the bottom
        positions = [
            (padding + 100, height - padding - 100),
            (width * 1/5, height - padding - 100),
            (width * 2/5, height - padding - 100),
            (width * 3/5, height - padding - 100),
            (width * 4/5, height - padding - 100),
            (width - padding - 100, height - padding - 100)
        ]
        
        # Draw each realistic rose
        for x, y in positions:
            self.flower_gen.draw_realistic_rose(canvas, x, y)
    
    def random_color(self):
        """Generate a random color in hex format"""
        r = random.randint(0, 255)
        g = random.randint(0, 255)
        b = random.randint(0, 255)
        return f"#{r:02x}{g:02x}{b:02x}"
    
    def random_glass_color(self):
        """Generate a random glass/tint color"""
        return random.choice([
            "#aaccff", "#bbddff", "#cceeff", "#ddeeff", 
            "#99bbff", "#88aadd", "#7799cc", "#6688bb"
        ])

# add rounded rectangle function to Canvas class
def create_round_rect(self, x1, y1, x2, y2, radius=10, **kwargs):
    points = [
        x1+radius, y1,
        x1+radius, y1,
        x2-radius, y1,
        x2-radius, y1,
        x2, y1,
        x2, y1+radius,
        x2, y1+radius,
        x2, y2-radius,
        x2, y2-radius,
        x2, y2,
        x2-radius, y2,
        x2-radius, y2,
        x1+radius, y2,
        x1+radius, y2,
        x1, y2,
        x1, y2-radius,
        x1, y2-radius,
        x1, y1+radius,
        x1, y1+radius,
        x1, y1
    ]
    return self.create_polygon(points, **kwargs, smooth=True)

tk.Canvas.create_round_rect = create_round_rect

if __name__ == "__main__":
    root = tk.Tk()
    app = CarInventorySimulation(root)
    root.mainloop()