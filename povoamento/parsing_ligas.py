import re
import json


f = open('ligas2021.json')

content = json.load(f)

f.close()

output_file = open("povoamento_ligas.sql",'w+')

for block in content["response"]:
    id_liga = block["id"]
    nome = block["name"]
    liga = block["country"]["name"]
    output_file.write("Insert into [Equipa] VALUES('" + str(id_equipa) + "', '" + str(nome) 
                        + "', '" + str(localizacao_liga) + "');\n")

    
output_file.close()
# print(json.dumps(ligas,ident=4))