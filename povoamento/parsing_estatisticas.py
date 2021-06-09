import re
import json


f = open('jsonConsultados/jogos_usa_2021.json')

content = json.load(f)

f.close()

output_file = open("estatisticas_jogos_usa.sql",'w+')

equipas = {}

for block in content["response"]:
    id_jogo = block["id"]
    data = block["date"]
    hora = block["time"]
    estado = block["status"]["short"]
    id_equipa_casa = block["teams"]["home"]["id"]
    id_equipa_visitante = block["teams"]["away"]["id"]

    if id_equipa_casa not in equipas:
        equipas[id_equipa_casa] = {}
        equipas[id_equipa_casa]['v'] = 0
        equipas[id_equipa_casa]['d'] = 0
        equipas[id_equipa_casa]['p'] = 0
        equipas[id_equipa_casa]['pm'] = 0
        equipas[id_equipa_casa]['ps'] = 0

    if id_equipa_visitante not in equipas:
        equipas[id_equipa_visitante] = {}
        equipas[id_equipa_visitante]['v'] = 0
        equipas[id_equipa_visitante]['d'] = 0
        equipas[id_equipa_visitante]['p'] = 0  
        equipas[id_equipa_visitante]['pm'] = 0
        equipas[id_equipa_visitante]['ps'] = 0   

    if estado == 'FT' or estado == 'AOT':
        total_casa = block["scores"]["home"]["total"]
        total_visitante = block["scores"]["away"]["total"]
        resultado = f'{total_casa} - {total_visitante}'

        equipas[id_equipa_casa]['pm'] += block["scores"]["home"]["total"]
        equipas[id_equipa_visitante]['ps'] += block["scores"]["home"]["total"]

        equipas[id_equipa_casa]['ps'] += block["scores"]["away"]["total"]
        equipas[id_equipa_visitante]['pm'] += block["scores"]["away"]["total"]

        if total_casa > total_visitante:
            equipas[id_equipa_casa]['v'] += 1
            equipas[id_equipa_casa]['p'] += 2
            equipas[id_equipa_visitante]['d'] += 1
            equipas[id_equipa_visitante]['p'] += 1
        else:
            equipas[id_equipa_casa]['d'] += 1
            equipas[id_equipa_casa]['p'] += 1
            equipas[id_equipa_visitante]['v'] += 1
            equipas[id_equipa_visitante]['p'] += 2
            
        
    else:
        resultado = f'Game Not Over'

    equipas = dict(sorted(equipas.items(),key=lambda p:p[1]['p'],reverse=True))

classificação = 1

for equipa in equipas.keys():
    valores = equipas.get(equipa)
    output_file.write("Insert into [Estatisticas] VALUES('" 
    + str(valores['pm']) + "', '" + str(valores['ps']) 
    + "', '" + str(valores['v']) + "', '" + str(valores['d']) 
    + "', '" + str(classificação) 
    + "', '" + str(valores['pm']-valores['ps'])
    + "', '"+ str(equipa) + "');\n")

    classificação += 1 
    
output_file.close()
# print(json.dumps(equipas,indent=4))