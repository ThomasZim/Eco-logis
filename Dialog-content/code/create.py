from PIL import Image, ImageDraw, ImageColor
from constants import MARGIN, X_CORNER, Y_CORNER, RECT_W, RECT_H, X_OBJECT, Y_OBJECT, NOTES, OBJECTS, WIDTH, HEIGHT

# import pandas lib as pd
import pandas as pd
 
# read by default 1st sheet of an excel file
dataframe1 = pd.read_excel('book2.xlsx')
 
print(dataframe1)

def draw_rounded_rectangle(draw, width, height, border_radius):
    draw.rounded_rectangle(
        [(X_CORNER, Y_CORNER), (width, height)],
        fill="#A5BEDC90",  # Rectangle color
        outline=None,
        radius=border_radius,
        width=0,
    )

def add_note(image, name):
    # Open the PNG image
    logo_image = Image.open("images/notes/" + name + ".png")

    # Calculate the position to paste the logo image
    logo_position = (X_CORNER - logo_image.width // 2, Y_CORNER - logo_image.height // 2)

    # Paste the logo image at the calculated position
    image.paste(logo_image, logo_position, logo_image)

def add_object(image, name):
    # Open the PNG image
    logo_image = Image.open("images/objects/" + name + ".png")

    # Calculate the position to paste the logo image
    logo_position = (X_OBJECT, Y_OBJECT)

    # Paste the logo image at the calculated position
    image.paste(logo_image, logo_position, logo_image)

def create_image(note, obj):
    # Create a new image with RGBA mode and transparent background
    image = Image.new("RGBA", (WIDTH, HEIGHT))

    # Create a drawing object
    draw = ImageDraw.Draw(image)

    # Draw a rounded rectangle with border radius
    border_radius = 15
    draw_rounded_rectangle(draw, RECT_W, RECT_H, border_radius)

    # Add the logo to the image
    add_note(image, note)
    add_object(image, obj)

    # Save the image
    image.save("output/" + obj + "_" + note + ".png")

if __name__ == "__main__":
    for note in NOTES:
        for obj in OBJECTS:
            create_image(note, obj)