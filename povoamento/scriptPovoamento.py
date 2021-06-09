import http.client
import requests
import json
import re

api_key = "f82e6188852496a6dd00a0223e321144"

headers = {
    'x-rapidapi-host': "v1.basketball.api-sports.io",
    'x-rapidapi-key': api_key
    }

url = "https://v1.basketball.api-sports.io/teams?league=10&season=2020-2021"

JSONContent = requests.get(url,headers=headers).json()

out_file = open("equipas_frW_2021.json", "w")

content = json.dump(JSONContent,out_file,indent=4)

out_file.close()