﻿namespace Cinema.Filmes.Api
{
    public static class ConfigurationExtensions
    {
        public static T SafeGet<T>(this IConfiguration configuration)
        {
            var typeName = typeof(T).Name;

            if (configuration.GetChildren().Any(item => item.Key == typeName))
            {
                configuration = configuration.GetSection(typeName);
            }

            T model = configuration.Get<T>();

            if (model == null)
            {
                throw new InvalidOperationException(
                    $"Item de configuracao nao encontrado para o tipo {typeof(T).FullName}.");
            }

            return model;
        }
    }
}
