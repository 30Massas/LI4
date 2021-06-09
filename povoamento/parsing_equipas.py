import re
import json


f = open('equipas_frW_2021.json')

content = json.load(f)

f.close()

output_file = open("sqlFiles/povoamento_equipa_frW.sql",'w+')

for block in content["response"]:
    id_liga = content["parameters"]["league"]
    nome = block["name"]
    id_equipa = block["id"]
    localizacao_equipa = block["country"]["name"]
    output_file.write("Insert into [Equipa] VALUES('" + str(id_equipa) + "', '" + str(nome) 
                        + "', '" + str(localizacao_equipa)+ "', '" + str(id_liga) + "');\n")

    
output_file.close()
# print(json.dumps(ligas,ident=4))