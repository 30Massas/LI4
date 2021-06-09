import re
import json


f = open('jogos_frW_2021.json')

content = json.load(f)

f.close()

output_file = open("sqlFiles/povoamento_jogos_frW.sql",'w+')

for block in content["response"]:
    id_jogo = block["id"]
    data = block["date"]
    hora = block["time"]
    estado = block["status"]["short"]
    id_equipa_casa = block["teams"]["home"]["id"]
    id_equipa_visitante = block["teams"]["away"]["id"]
    if estado == 'FT' or estado == 'AOT':
        total_casa = block["scores"]["home"]["total"]
        total_visitante = block["scores"]["away"]["total"]
        resultado = f'{total_casa} - {total_visitante}'
    else:
        resultado = f'Game Not Over'

    output_file.write("Insert into [Jogo] VALUES('" + str(id_jogo) + "', '" + str(data) 
                + "', '" + str(hora) + "', '" + str(resultado) 
                + "', '" + str(id_equipa_casa) + "', '" + str(id_equipa_visitante) + "');\n")

    
output_file.close()
# print(json.dumps(ligas,ident=4))