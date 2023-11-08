import numpy as np
import matplotlib.pyplot as plt

# Define the time range
hours = np.arange(6*60, 23*60+1) / 60.0

# Define events as dictionaries with hour as key and bonus/malus value as value
# For example: faim_events = {10: 20, 15: -10} means +20 to Faim at 10h and -10 at 15h
faim_events = {7: -50, 12: -100, 19: -80}
soif_events = {7: 10, 19: 20}
vessie_events = {9: -100, 14: -100, 20: -100}
confort_events = {}
hygiene_events = {21: 100}
plaisir_events = {19.5: 20}

capitale_events = {}
revenu_events = {}
energie_events = {}
loyer_events = {}
achat_events = {}

# Personne variables and their rates of change
faim = np.zeros(hours.shape[0])
soif = np.zeros(hours.shape[0])
vessie = np.zeros(hours.shape[0])
confort = np.zeros(hours.shape[0])
hygiene = np.zeros(hours.shape[0])
plaisir = np.zeros(hours.shape[0])
energie = np.zeros(hours.shape[0])

# Define weights for each attribute
weights = {
    "Faim": 0.20,
    "Soif": 0.20,
    "Vessie": 0.10,
    "Confort": 0.20,
    "Hygiène": 0.10,
    "Plaisir": 0.20
}

# Financial variables and their rates of change
capitale = np.zeros(hours.shape[0])
revenu = np.zeros(hours.shape[0])
energie_fin = np.zeros(hours.shape[0])
loyer = np.zeros(hours.shape[0])
achat = np.zeros(hours.shape[0])

# Initialize starting values (feel free to modify these)
faim[0] = 80
soif[0] = 80
vessie[0] = 50
confort[0] = 80
hygiene[0] = 50
plaisir[0] = 50
capitale[0] = 500
revenu[0] = 50
energie[0] = 50
loyer[0] = 0
achat[0] = 0

# Define the rates of change for each variable (modify these as needed)
faim_rate = 10 / 60.0
soif_rate = -4 / 60.0
vessie_rate = 5 / 60.0
confort_rate = -3 / 60.0
hygiene_rate = -2 / 60.0
plaisir_rate = -1 / 60.0
capitale_rate = 0 / 60.0
revenu_rate = 10 / 60.0
energie_rate = -2 / 60.0
loyer_rate = -50 / 60.0
achat_rate = -30 / 60.0

# Define a function to get the event amount for a given hour
def get_event_amount(hour, event_dict):
    return event_dict.get(hour, 0)  # Returns 0 if no event for the given hour

# Calculate values for each hour (with events integrated)
for i in range(1, hours.shape[0]):
    faim[i] = max(0, min(100, faim[i-1] + faim_rate + get_event_amount(hours[i], faim_events)))
    soif[i] = max(0, min(100, soif[i-1] + soif_rate + get_event_amount(hours[i], soif_events)))
    vessie[i] = max(0, min(100, vessie[i-1] + vessie_rate + get_event_amount(hours[i], vessie_events)))
    confort[i] = max(0, min(100, confort[i-1] + confort_rate + get_event_amount(hours[i], confort_events)))
    hygiene[i] = max(0, min(100, hygiene[i-1] + hygiene_rate + get_event_amount(hours[i], hygiene_events)))
    plaisir[i] = max(0, min(100, plaisir[i-1] + plaisir_rate + get_event_amount(hours[i], plaisir_events)))
    capitale[i] = capitale[i-1] + revenu_rate + loyer_rate + achat_rate + get_event_amount(hours[i], capitale_events)
    revenu[i] = revenu[i-1] + get_event_amount(hours[i], revenu_events)
    energie[i] = max(0, min(100, energie[i-1] + energie_rate + get_event_amount(hours[i], energie_events)))
    loyer[i] = loyer[i-1] + get_event_amount(hours[i], loyer_events)
    achat[i] = achat[i-1] + get_event_amount(hours[i], achat_events)
    
# Initialize the WellBeing array
well_being = np.zeros(hours.shape[0])

# Calculate the WellBeing value for each hour
for i in range(hours.shape[0]):
    well_being[i] = ((100-faim[i]) * weights["Faim"] + 
                     (100-soif[i]) * weights["Soif"] + 
                     (100-vessie[i]) * weights["Vessie"] + 
                     confort[i] * weights["Confort"] + 
                     hygiene[i] * weights["Hygiène"] + 
                     plaisir[i] * weights["Plaisir"])


# Plot Personne variables
plt.figure(1,figsize=(12, 8))
plt.title("Personne variables over time")
plt.plot(hours, faim, label="Faim")
plt.plot(hours, soif, label="Soif")
plt.plot(hours, vessie, label="Vessie")
plt.plot(hours, confort, label="Confort")
plt.plot(hours, hygiene, label="Hygiène")
plt.plot(hours, plaisir, label="Plaisir")
plt.xlabel("Hours")
plt.ylabel("Value")
plt.legend()
plt.grid(True)
#plt.show()

# Plot Financial variables
plt.figure(2,figsize=(12, 8))
plt.title("Financial variables over time")
plt.plot(hours, capitale, label="Capitale")
plt.plot(hours, revenu, label="Revenu")
plt.plot(hours, energie_fin, label="Energie")
plt.plot(hours, loyer, label="Loyer")
plt.plot(hours, achat, label="Achat")
plt.xlabel("Hours")
plt.ylabel("Value")
plt.legend()
plt.grid(True)
#plt.show()

# Plot WellBeing variable
plt.figure(3,figsize=(12, 8))
plt.title("WellBeing over time")
plt.plot(hours, well_being, label="WellBeing", color='purple')
plt.xlabel("Hours")
plt.ylabel("Value")
plt.legend()
plt.grid(True)
plt.show()