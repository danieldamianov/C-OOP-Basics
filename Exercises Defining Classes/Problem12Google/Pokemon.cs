public class Pokemon
{
    public string PokemonName { get; set; }

    public string PokemonType { get; set; }

    public Pokemon(string pokemonName , string pokemonType)
    {
        this.PokemonName = pokemonName;
        this.PokemonType = pokemonType;
    }

    public override string ToString()
    {
        return $"{this.PokemonName} {this.PokemonType}";
    }
}