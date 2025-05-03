# flowers.py
import random
import math

class FlowerGenerator:
    def __init__(self):
        self.rose_colors = [
            "#FF007F",  # rose pink
            "#C71585",  # medium Violet red
            "#DC143C",  # crimson red
            "#FF0000",  # classic red
            "#FF69B4",  # hot pink
            "#FF1493",  # deep pink
            "#DB7093",  # pale Violet red
            "#FF6347",  # tomato orange
            "#FF4500",  # orange red
            "#FF8C00"   # dark orange
        ]

        self.leaf_colors = ["#2E8B57", "#3CB371", "#228B22", "#006400"]
        self.stem_colors = ["#2E8B57", "#3CB371", "#228B22"]
        
    def draw_realistic_rose(self, canvas, x, y):
        """Draw a highly realistic rose at fixed position (x,y) with random colors/sizes"""
        # fixed stem height and width
        stem_height = 100
        stem_width = 3
        
        # random colors
        stem_color = random.choice(self.stem_colors)
        rose_color = random.choice(self.rose_colors)
        leaf_color = random.choice(self.leaf_colors)
        
        # draw stem with slight natural curve
        stem_curve = random.uniform(-15, 15)
        canvas.create_line(x, y, 
                         x + stem_curve, y - stem_height, 
                         fill=stem_color, width=stem_width, smooth=True)
        
        # flower center position
        flower_y = y - stem_height
        
        # draw leaves at fixed positions along stem
        leaf_size = random.randint(15, 25)
        self.draw_realistic_leaf(canvas, x, y - stem_height//3, leaf_size, leaf_color)
        self.draw_realistic_leaf(canvas, x, y - 2*stem_height//3, leaf_size, leaf_color)
        
        # draw rose with layered petals
        petal_layers = random.randint(4, 6)  # More layers for realism
        
        for layer in range(petal_layers, 0, -1):
            layer_size = layer * 7  # outer layers are larger
            petal_count = 5 if layer == petal_layers else random.randint(8, 12)
            
            for i in range(petal_count):
                angle = math.radians(i * (360 / petal_count) + random.uniform(-10, 10))
                petal_x = x + layer_size * (1 + 0.5*(layer/petal_layers)) * math.cos(angle)
                petal_y = flower_y + layer_size * (0.8 + 0.2*(layer/petal_layers)) * math.sin(angle)
                
                #draw petal with turtle-inspired curved shape
                self.draw_curved_petal(canvas, x, flower_y, petal_x, petal_y, 
                                      size=layer_size, color=rose_color, layer=layer)
        
        # draw flower center
        center_size = random.randint(4, 8)
        center_color = self.adjust_color(rose_color, -40)
        canvas.create_oval(
            x - center_size, flower_y - center_size,
            x + center_size, flower_y + center_size,
            fill=center_color, outline=self.adjust_color(rose_color, -60), width=1)
    
    def draw_curved_petal(self, canvas, center_x, center_y, tip_x, tip_y, size, color, layer):
        """Draw a petal with turtle-inspired curved shape"""
        # control points for bezier curves to create natural petal shape
        cp1_x = center_x + (tip_x - center_x) * 0.3
        cp1_y = center_y - size * 0.2
        
        cp2_x = tip_x
        cp2_y = tip_y - size * 0.3
        
        # create petal shape using bezier curves
        points = []
        steps = 20
        for i in range(steps + 1):
            t = i / steps
            # bezier curve from center to tip
            x = (1-t)**3 * center_x + 3*(1-t)**2*t*cp1_x + 3*(1-t)*t**2*cp2_x + t**3*tip_x
            y = (1-t)**3 * center_y + 3*(1-t)**2*t*cp1_y + 3*(1-t)*t**2*cp2_y + t**3*tip_y
            points.extend([x, y])
        
        # curve back down the other side
        cp3_x = tip_x
        cp3_y = tip_y + size * 0.4
        
        cp4_x = center_x + (tip_x - center_x) * 0.5
        cp4_y = center_y + size * 0.3
        
        for i in range(steps + 1):
            t = i / steps
            x = (1-t)**3 * tip_x + 3*(1-t)**2*t*cp3_x + 3*(1-t)*t**2*cp4_x + t**3*center_x
            y = (1-t)**3 * tip_y + 3*(1-t)**2*t*cp3_y + 3*(1-t)*t**2*cp4_y + t**3*center_y
            points.extend([x, y])
        
        # vary petal color slightly for depth
        petal_color = self.adjust_color(color, random.randint(-15, 15)) if layer > 1 else color
        outline_color = self.adjust_color(petal_color, -30)
        
        canvas.create_polygon(
            points,
            fill=petal_color,
            outline=outline_color,
            width=1,
            smooth=True
        )
        
        # add subtle petal vein
        vein_y_offset = random.uniform(0.1, 0.3) * size
        canvas.create_line(
            center_x, center_y,
            tip_x, tip_y + vein_y_offset,
            fill=outline_color,
            width=1,
            smooth=True
        )
    
    def draw_realistic_leaf(self, canvas, x, y, size, color):
        """rose leaf with serrated edges"""
        # determine leaf direction
        direction = random.choice([-1, 1])
        
        # leaf shape points
        points = [x, y]  # start at stem
        
        # leaf tip
        tip_x = x + direction * size
        tip_y = y - size
        points.extend([tip_x, tip_y])
        
        # create serrated edges
        num_serrations = random.randint(5, 8)
        for i in range(1, num_serrations + 1):
            pos = i / (num_serrations + 1)
            serration_x = x + direction * size * (1 - pos)
            serration_depth = random.uniform(0.15, 0.35) * size
            
            if i % 2 == 0:
                serration_y = y - size * pos + serration_depth
            else:
                serration_y = y - size * pos - serration_depth
            
            points.extend([serration_x, serration_y])
        
        # back to stem
        points.extend([x + direction * size * 0.3, y])
        
        # draw leaf
        vein_color = self.adjust_color(color, -20)
        
        canvas.create_polygon(
            points,
            fill=color,
            outline=vein_color,
            width=1,
            smooth=True
        )
        
        # draw main vein
        canvas.create_line(
            x, y,
            tip_x, tip_y,
            fill=vein_color,
            width=1
        )
        
        # draw secondary veins
        num_veins = random.randint(5, 7)
        for i in range(1, num_veins + 1):
            vein_pos = i / (num_veins + 1)
            vein_x = x + direction * size * (1 - vein_pos)
            vein_y = y - size * vein_pos
            
            canvas.create_line(
                x + direction * size * 0.3 * vein_pos, y,
                vein_x, vein_y,
                fill=vein_color,
                width=1
            )
    
    def adjust_color(self, hex_color, amount):
        """Lighten or darken a hex color by the specified amount"""
        hex_color = hex_color.lstrip('#')
        rgb = tuple(int(hex_color[i:i+2], 16) for i in (0, 2, 4))

        new_rgb = []
        for channel in rgb:
            new_channel = max(0, min(255, channel + amount))
            new_rgb.append(new_channel)
        
        return "#{:02x}{:02x}{:02x}".format(*new_rgb)