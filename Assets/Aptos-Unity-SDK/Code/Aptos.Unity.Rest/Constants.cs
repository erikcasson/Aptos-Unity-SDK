namespace Aptos.Rest
{
    public class Constants
    {
        public const string MAINNET_BASE_URL = "https://fullnode.mainnet.aptoslabs.com/v1";
        public const string TESTNET_BASE_URL = "https://fullnode.testnet.aptoslabs.com/v1";
        public const string DEVNET_BASE_URL = "https://fullnode.devnet.aptoslabs.com/v1";

        public const string APTOS_COIN_TYPE = "0x1::coin::CoinStore<0x1::aptos_coin::AptosCoin>";

        public const int EXPIRATION_TTL = 600;
        public const int GAS_UNIT_PRICE = 100;
        public const int MAX_GAS_AMOUNT = 100000;
        public const int TRANSACTION_WAIT_IN_SECONDS = 20;

        public const string ED25519_SIGNATURE = "ed25519_signature";
        public const string ENTRY_FUNCTION_PAYLOAD = "entry_function_payload";
        public const string CREATE_TOKEN_SCRIPT_FUNCTION = "0x3::token::create_token_script";
        public const string CREATE_COLLECTION_SCRIPT = "0x3::token::create_collection_script";
        public const string COIN_TRANSFER_FUNCTION = "0x1::coin::transfer";
        public const string APTOS_ASSET_TYPE = "0x1::aptos_coin::AptosCoin";
    }
}