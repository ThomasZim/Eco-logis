from PIL import Image, ImageDraw, ImageFont
from constants import MARGIN, X_CORNER, Y_CORNER, X_OBJECT, Y_OBJECT, LARGE_IMAGE_SIZE, SMALL_IMAGE_SIZE, OBJECT_NAMES, FONT_SIZE, WIDTH, UNIT, OBJECTS

# import pandas lib as pd
import pandas as pd

# Draw a rounded rectangle with border radius
def draw_rounded_rectangle(draw, width, height, border_radius):
    draw.rounded_rectangle(
        [(X_CORNER, Y_CORNER), (width, height)],
        fill="#A5BEDC",  # Rectangle color
        outline=None,
        radius=border_radius,
        width=0,
    )

# Add the note to the image
def add_note(image, name):
    # Open the PNG image
    note_image = Image.open("images/notes/" + name + ".png")

    # Calculate the position to paste the image
    logo_position = (X_CORNER - note_image.width // 2, Y_CORNER - note_image.height // 2)

    # Paste the image at the calculated position
    image.paste(note_image, logo_position, note_image)

def add_image(image, path, position, size=None):
    # Open the PNG image
    img = Image.open(path)

    if size is None:
        # Set size to SMALL_IMAGE_SIZE if it's None
        size = SMALL_IMAGE_SIZE

    img = img.resize((size, size))

    # Paste the image at the specified position
    image.paste(img, position, img)

# Add the object to the image
def add_object(draw, image, name, object_index):
    object_image_path = "images/objects/" + name + ".png"
    position = (X_OBJECT, Y_OBJECT)
    add_image(image, object_image_path, position, LARGE_IMAGE_SIZE)

    # Add text to the image
    text = OBJECT_NAMES[object_index]
    font_color = "#FFFFFF"  # RGB color code for white text
    font = ImageFont.truetype(r'/Users/clarisse/Documents/Roboto/Roboto-Bold.ttf', FONT_SIZE)  

    # Calculate the position to center the text
    text_bbox = draw.textbbox((0, 0), text, font=font)
    x = WIDTH - MARGIN - text_bbox[2] - text_bbox[0]
    y = Y_OBJECT + FONT_SIZE // 2

    # Draw the text on the image using the defined font_size and text_bbox
    draw.text((x, y), text, font=font, fill=font_color, align ="right")


# Add the action info to the image
def add_action_info(draw, image, is_on):
    action_image_path = "images/e_action.png"
    position = (X_OBJECT + (LARGE_IMAGE_SIZE - SMALL_IMAGE_SIZE) // 2,
                Y_OBJECT + LARGE_IMAGE_SIZE + MARGIN)
    add_image(image, action_image_path, position, SMALL_IMAGE_SIZE)

    # Add text to the image
    text = "Turn ON" if is_on else "Turn OFF"
    font_color = "#FFFFFF"  # RGB color code for white text
    font = ImageFont.truetype(r'/Users/clarisse/Documents/Roboto/Roboto-Regular.ttf', FONT_SIZE)  

    # Calculate the position to center the text
    text_bbox = draw.textbbox((0, 0), text, font=font)
    x = WIDTH - MARGIN - text_bbox[2] - text_bbox[0]
    y = Y_OBJECT + LARGE_IMAGE_SIZE + MARGIN + FONT_SIZE // 2

    # Draw the text on the image using the defined font_size and text_bbox
    draw.text((x, y), text, font=font, fill=font_color, align ="right")

# Add the action info to the image
def add_price_info(draw, image, object_index, note, excel_file):
    image_path = "images/money.png"
    position = (X_OBJECT + (LARGE_IMAGE_SIZE - SMALL_IMAGE_SIZE) // 2,
                Y_OBJECT + LARGE_IMAGE_SIZE + MARGIN)
    add_image(image, image_path, position, SMALL_IMAGE_SIZE)
    
    try:
        #print("Price")
        price = excel_file.loc[(excel_file["Objet"] == OBJECTS[object_index]) & (excel_file["Note"] == note.upper()), "Finance"].values[0]
        price = float(format(price, '.2f'))
    except:
        return

    # Add text to the image
    text = str(price) + " $"
    font_color = "#FFFFFF"  # RGB color code for white text
    font = ImageFont.truetype(r'/Users/clarisse/Documents/Roboto/Roboto-Regular.ttf', FONT_SIZE)  

    # Calculate the position to center the text
    text_bbox = draw.textbbox((0, 0), text, font=font)
    x = WIDTH - MARGIN - text_bbox[2] - text_bbox[0]
    y = Y_OBJECT + LARGE_IMAGE_SIZE + MARGIN + FONT_SIZE // 2

    # Draw the text on the image using the defined font_size and text_bbox
    draw.text((x, y), text, font=font, fill=font_color, align ="right")

# Add the energy info to the image
def add_energy_info(draw, image, object_index, note, excel_file):
    energy_image_path = "images/energy.png"
    position = (X_OBJECT + (LARGE_IMAGE_SIZE - SMALL_IMAGE_SIZE) // 2,
                Y_OBJECT + LARGE_IMAGE_SIZE + MARGIN + SMALL_IMAGE_SIZE + MARGIN)
    add_image(image, energy_image_path, position, SMALL_IMAGE_SIZE)

    try:
        energy = excel_file.loc[(excel_file["Objet"] == OBJECTS[object_index]) & (excel_file["Note"] == note.upper()), "Energie"].values[0]
        energy = float(format(energy, '.2f'))
        unit = excel_file.loc[(excel_file["Objet"] == OBJECTS[object_index]) & (excel_file["Note"] == note.upper()), "Unité"].values[0]
        if unit == "0":
            unit = UNIT
    except:
        return False

    # Add text to the image
    text = str(energy) + " " + unit
    font_color = "#FFFFFF"  # RGB color code for white text
    font = ImageFont.truetype(r'/Users/clarisse/Documents/Roboto/Roboto-Regular.ttf', FONT_SIZE)  

    # Calculate the position to center the text
    text_bbox = draw.textbbox((0, 0), text, font=font)
    x = WIDTH - MARGIN - text_bbox[2] - text_bbox[0]
    y = Y_OBJECT + LARGE_IMAGE_SIZE + MARGIN + SMALL_IMAGE_SIZE + MARGIN + FONT_SIZE // 2

    # Draw the text on the image using the defined font_size and text_bbox
    draw.text((x, y), text, font=font, fill=font_color, align ="right")
    return True
    