FROM node:alpine

WORKDIR /app

COPY package*.json ./
COPY . /app

RUN npm install
RUN npm rebuild node-sass

CMD ["npm", "start"]