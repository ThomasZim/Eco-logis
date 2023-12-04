from PIL import Image, ImageDraw, ImageFont
from constants import RECT_W, RECT_H, NOTES, OBJECTS, WIDTH, HEIGHT, OBJECT_NAMES
from add_images import draw_rounded_rectangle, add_note, add_object, add_energy_info, add_action_info

# import pandas lib as pd
import pandas as pd
 
# read by default 1st sheet of an excel file
#dataframe1 = pd.read_excel('book2.xlsx')
 
#print(dataframe1)

def create_image(note, obj, object_index, is_on):
    # Create a new image with RGBA mode and transparent background
    image = Image.new("RGBA", (WIDTH, HEIGHT))

    # Create a drawing object
    draw = ImageDraw.Draw(image)

    # Draw a rounded rectangle with border radius
    border_radius = 15
    draw_rounded_rectangle(draw, RECT_W, RECT_H, border_radius)

    # Add the logo to the image
    add_note(image, note)
    add_object(draw, image, obj, object_index)
    add_action_info(draw, image, is_on)
    add_energy_info(image)

    # Save the image
    image.save("output/" + obj + "_" + note + "_" + ("on" if is_on else "off") + ".png")

if __name__ == "__main__":
    for note in NOTES:
        object_index = 0
        for obj in OBJECTS:
            create_image(note, obj, object_index, True)
            create_image(note, obj, object_index, False)
            object_index += 1