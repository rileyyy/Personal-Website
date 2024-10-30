FROM node:lts-alpine

ARG ENVIRONMENT=production
ENV ENVIRONMENT $ENVIRONMENT

WORKDIR /app/website

COPY website/package*.json ./
RUN npm install

COPY --chown=app:app website/. .

# Development-specific logic for watching files
RUN if [ "$ENVIRONMENT" = "development" ]; then npm install -g nodemon; fi

CMD sh -c "if [ \"$ENVIRONMENT\" = development ]; then npm run dev; else npm run build && npm run start; fi"
