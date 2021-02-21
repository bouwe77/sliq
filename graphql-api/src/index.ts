require("dotenv").config();
import { ApolloServer } from "apollo-server";

import typeDefs from "./typeDefs";
import resolvers from "./resolvers";
import dataSources from "./dataSources";

const server = new ApolloServer({ typeDefs, resolvers, dataSources });

server
  .listen({ port: process.env.PORT || 4000 })
  .then(({ url }) => console.log(`🚀 GraphQL running at ${url}`));
