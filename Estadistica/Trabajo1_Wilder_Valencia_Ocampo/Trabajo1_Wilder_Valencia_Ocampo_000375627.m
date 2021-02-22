%Limpieza Inicial de Workspace y la command Windows
clear
clc

%Datos Obtenidos experimentalmente en el juego de azar
Datos=[zeros(1,35),10*ones(1,21),20*ones(1,7),40*ones(1,7),50*ones(1,3),60*ones(1,4),70*ones(1,4),90*ones(1,12),100*ones(1,7)]
NumeroLanzamientos=100
%%GRAFICAS EXPERIMENTO

%histograma experimento
figure(1)
hist(Datos,[0,10,20,40,50,60,70,90,100])
title('Histrograma EXPERIMENTO')

%distribuccion de probabilidad experimento
[D1 ValVariableAle]=hist(Datos,[0,10,20,40,50,60,70,90,100])
probabilidad=D1/NumeroLanzamientos
figure(2)
bar(ValVariableAle,probabilidad)
title('Distribuccion de Probabilidad EXPERIEMENTO')

%distribuccion de probabilidad acumulada experimento
PAcumuladaSimulacion=cumsum(probabilidad)
figure(3)
bar(ValVariableAle,PAcumuladaSimulacion)
title('Distribuccion de Probabilidad Acumulada EXPERIEMENTO')



%%Simulacion
Nlanzamientos=100;
for i=1:Nlanzamientos
    Aletorio=rand()
    if Aletorio<PAcumuladaSimulacion(1) VectorLanzamientos(i)=0
    elseif Aletorio<PAcumuladaSimulacion(2) VectorLanzamientos(i)=10
    elseif Aletorio<PAcumuladaSimulacion(3) VectorLanzamientos(i)=20
    elseif Aletorio<PAcumuladaSimulacion(4) VectorLanzamientos(i)=40
    elseif Aletorio<PAcumuladaSimulacion(5) VectorLanzamientos(i)=50
    elseif Aletorio<PAcumuladaSimulacion(6) VectorLanzamientos(i)=60
    elseif Aletorio<PAcumuladaSimulacion(7) VectorLanzamientos(i)=70
    elseif Aletorio<PAcumuladaSimulacion(8) VectorLanzamientos(i)=90
    else VectorLanzamientos(i)=100
    end
end
%Figuras sobre las simulacion

%histograma simulacion
figure(4)
hist(VectorLanzamientos,ValVariableAle)
title('Histrograma SIMULACION')

%distribuccion de probabilidad simulacion
figure(5)
[D2 ValVariableAle]=hist(VectorLanzamientos,[0,10,20,40,50,60,70,90,100])
PSimulacion=D2/Nlanzamientos
bar(ValVariableAle, PSimulacion)
title('Distribuccion de Probabilidad SIMULACION')

%distribuccion de probabilidad acumulada simulacion
PAcumuladaSimulacion=cumsum(probabilidad)
figure(6)
bar(ValVariableAle,PAcumuladaSimulacion)
title('Distribuccion de Probabilidad Acumulada SIMULACION')


%Calculo de media y varianza para el EXPERIMENTO Y LA SIMULACION
mediaEXP=mean(Datos)
mediaSIMU=mean(VectorLanzamientos)
pErrorMedia=abs(((mediaSIMU-mediaEXP)/mediaEXP)*100)
Salida1=['Media Experimento= ',num2str(mediaEXP),'             Media Simulacion= ',num2str(mediaSIMU),'             %Error= ',num2str(pErrorMedia),'%']

varianzaEXP=var(Datos)
varianzaSIMU=var(VectorLanzamientos)
pErrorVarianza=abs(((varianzaSIMU-varianzaEXP)/varianzaEXP)*100)
Salida2=['Varianza Experimento= ',num2str(varianzaEXP),'     Varianza Simulacion= ',num2str(varianzaSIMU),'     %Error= ',num2str(pErrorVarianza),'%']

disp(Salida1)
disp(Salida2)
