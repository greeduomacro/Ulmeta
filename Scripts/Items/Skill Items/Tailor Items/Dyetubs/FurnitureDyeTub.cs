using System;

namespace Server.Items
{
	public class FurnitureDyeTub : DyeTub
	{
		public override bool AllowDyables { get { return false; } }
		public override bool AllowFurniture { get { return true; } }
		public override int TargetMessage { get { return 501019; } } // Select the furniture to dye.
		public override int FailMessage { get { return 501021; } } // That is not a piece of furniture.
		public override int LabelNumber { get { return 1041246; } } // Furniture Dye Tub

		[Constructable]
		public FurnitureDyeTub()
		{
			LootType = LootType.Blessed;
		}

		public FurnitureDyeTub( Serial serial )
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if( LootType == LootType.Regular )
				LootType = LootType.Blessed;
		}
	}
}