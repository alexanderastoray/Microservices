# Microservices
API Gateway est essentiellement une interface dans laquelle elle reçoit des appels et redirige vers des services internes. Fondamentalement, il est utilisé aux fins suivantes :

Routage : c'est l'une des fonctions clés d'une API Gateway. Fondamentalement, lorsque API Gateway reçoit une demande de l'extérieur, il transmet la demande à l'API interne de correspondance en fonction de la carte de routage. Cette fonctionnalité est identique à la fonctionnalité de réserve de proxy fournie par les serveurs Web comme NGINX.

Composition de l'API : une API Gateway agit non seulement comme un proxy inverse, mais implémente également certaines opérations d'API à l'aide de la composition d'API.

Par exemple, votre application propose une fonction «Reporting», cette fonction nécessite l'implication de 3 API (GetProducts, GetBill et GetInventory) qui appartiennent à 3 services différents: Produit, Paiement et Inventaire. Sans API Gateway, votre projet de fin de police devra appeler trois fois à trois API, à la place, nous avons juste besoin d'implémenter une passerelle API à l'aide de la fonction de composition d'API afin d'exposer un seul point de terminaison à externe (Reporting). Il aidera le projet de fin de police à récupérer efficacement les données par une seule demande d'API.

Caching : Mettre en cache les réponses afin de réduire les demandes aux services.

Journalisation : la fonction de journalisation est nécessaire pour le suivi et le débogage.

Intégration avec Identity Provider : au lieu de l'intégrer avec Identity Provider pour l'authentification et l'autorisation sur chaque service, nous pouvons centraliser cela dans API Gateway.

Limitation du débit : limiter le nombre de requêtes par seconde autorisées sur un client spécifique ou sur tous les clients.
API Gateway Pattern

Lors de la construction d'un système volumineux et complexe à l'aide de l'architecture de microservices avec plusieurs applications clientes, une bonne approche à considérer est le Pattern API Gateway.

Ce pattern fournit un point d'entrée unique pour les groupes de microservices. Une variante du modèle API Gateway est également connue sous le nom de «backend for frontend» (BFF) car vous pouvez créer plusieurs API Gateway en fonction des différents besoins de chaque application cliente.

Par conséquent, l’API Gateway se situe entre les applications clientes et les microservices. Il agit comme un proxy inverse, acheminant les demandes des clients vers les services.Il peut également fournir des fonctionnalités transversales supplémentaires telles que l'authentification, la terminaison SSL et le cache.

Avantages
Que vous utilisiez des microservices ou de l'informatique sans serveur ou que votre API soit utilisée en interne ou accessible au public, l'utilisation des Gateway API présente de nombreux avantages:

Découplage : si vos clients sur lesquels vous n'avez aucun contrôle communiquent directement avec de nombreux services distincts, renommer ou déplacer ces services peut être difficile car le client est couplé à l'architecture et à l'organisation sous-jacentes. Les API Gateway vous permettent de router en fonction du chemin d'accès, du nom d'hôte, des en-têtes et d'autres informations clés vous permettant de découpler les points de terminaison API publiquement accessibles de l'architecture de microservice sous-jacente.

Réduisez les allers-retours : certains points de terminaison API peuvent avoir besoin de joindre des données sur plusieurs services. Les API Gateway peuvent effectuer cette agrégation afin que le client n'ait pas besoin de chaînage d'appels compliqué et réduise le nombre d'aller-retour.

Sécurité : les passerelles API fournissent un serveur proxy centralisé pour gérer la limitation de débit, la détection des bots, l'authentification, CORS, entre autres. De nombreuses API Gateway permettent de configurer une banque de données telle que Redis pour stocker les informations de session.

# Ocelot

Ocelot est un middleware pour .net core qui permet de créer une « gateway » (un point d’entrée) unique pour un ensemble de micro service. C’est une sorte de router.

Caractéristiques d'Ocelot:

Acheminement
Demande d'agrégation
Découverte de service avec Consul & Eureka
Tissu de service
WebSockets
Authentification
Autorisation
Limitation de débit
Mise en cache
Réessayer les stratégies / QoS
L'équilibrage de charge
Journalisation / traçage / corrélation
En-têtes / Chaîne de requête / Transformation des revendications
Middleware personnalisé / gestionnaires de délégation
API REST de configuration / administration
Agnostique plateforme / cloud

Par exemple, admetons que l’on est deux services Asp.Net Core (ServiceTestA, ServiceTestB) qui tournent respectivement sur :

localhost:7001/api/ServiceA
localhost:7002/api/ServiceB

Chacun ayant un simple controler « racine » qui retourne n’importe quoi.
Ils sont à ce stade joigniables uniquement via ces url. On veut maintenant qu’ils soient tous accesibles depuis localhost:7000 :

localhost:7000/ServiceA
localhost:7000/ServiceB

Pour cela on va ajouter le middleware Ocelot https://ocelot.readthedocs.io/en/latest/introduction/bigpicture.html et le configurer 
